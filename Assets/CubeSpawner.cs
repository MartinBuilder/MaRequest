using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour {
    
    [SerializeField] private GameObject prefab;
    [SerializeField] private int size;

    private void Start() {
        for (int i = -size / 2; i < size / 2; i++) {
            for (int j = 0; j < size; j++) {
                var clone = Instantiate(prefab, transform, false);
                var offset = (j % 2) * 0.3f;
                clone.transform.position += new Vector3(i + offset, j, 0);
            }
        }
    }

}
