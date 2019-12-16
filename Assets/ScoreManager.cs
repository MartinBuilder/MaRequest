using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour {

    public static int Score {
        get; private set;
    } = 0;

    public static Action<int> ScoreAdded;
    [SerializeField] private TextMeshProUGUI scoreLabel;

    private void Awake() {
        Score = 0;
        ScoreAdded += OnScoreAdded;
    }

    private void Update() {
        scoreLabel.text = Score.ToString();

        Debug.Log(Camera.allCamerasCount);
    }

    private static void OnScoreAdded(int scoreToAdd) {
        Score += scoreToAdd;
        
    }

}
