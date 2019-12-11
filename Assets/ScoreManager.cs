using System;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public static float Score {
        get; private set;
    } = 0;

    public static Action<int> ScoreAdded;

    private void Awake() {
        Score = 0;
        ScoreAdded += OnScoreAdded;
    }

    private static void OnScoreAdded(int scoreToAdd) {
        Score += scoreToAdd;
    }

}
