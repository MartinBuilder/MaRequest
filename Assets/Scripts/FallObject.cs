using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallObject : MonoBehaviour {

    [SerializeField] private float maxFallDepth = -5;
    [SerializeField] private int scoreGain = 100;

    private void Update() {
        if (transform.position.y < maxFallDepth) {
            ScoreManager.ScoreAdded.Invoke(scoreGain);
            gameObject.SetActive(false);
        }
    }

}
