using System;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public static float Score {
        get; private set;
    } = 0;

    public static Action<> ScoreAdded;

    private void Awake() {
        Score = 0;
    }

    private static void OnScoreAdded(int scoreToAdd) {
        Score += scoreToAdd;
    }

}
