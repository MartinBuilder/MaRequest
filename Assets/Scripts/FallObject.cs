using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallObject : MonoBehaviour {

    [SerializeField] private float maxFallDepth = -1;

    private void Update() {
        if (transform.position.y < maxFallDepth) {
            ScoreManager.ScoreAdded.Invoke();
            gameObject.SetActive(false);
        }
    }

}
