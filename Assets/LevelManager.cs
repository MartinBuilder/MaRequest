using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    [SerializeField] private List<Level> levels = new List<Level>();

    private Level currentLevel;
    private int levelCounter;

    public static LevelManager instance {
        get; private set;
    }

    private void OnEnable() {
        instance = this;
    }

    public void Start() {
        if(levels?.Count > 0) {
            NextLevel();
        }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.N)) {
            NextLevel();
        }
    }

    public void SetLevel(Level level) {
        currentLevel = level;
        currentLevel.Generate();
    }

    public void NextLevel() {
        if (currentLevel == null) {
            SetLevel(levels[0]);
            levelCounter = 0;
        } else {
            levelCounter++;
            if(levelCounter > levels.Count - 1) {
                // Go to score screen
            } else {
                SetLevel(levels[levelCounter]);
            }
        }
    }

}
