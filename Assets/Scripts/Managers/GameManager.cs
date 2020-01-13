using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private FallObjectManager objectManager;
    private LevelManager levelManager;
    [SerializeField] private SnowballStack snowballStack;

    private void Start() {
        objectManager = FallObjectManager.instance;
        levelManager = LevelManager.instance;
    }

    private void Update() {

        TestForNextLevel();

    }

    private void TestForNextLevel() {

        if(objectManager.AmountOfActiveObjects() <= 0) {
            levelManager.NextLevel();
            snowballStack.RefillStack();
        }

        if(snowballStack.SnowballsEmpty() && snowballStack.NoSnowballsActive()) {
            levelManager.NextLevel();
            snowballStack.RefillStack();
        }
    }

}
