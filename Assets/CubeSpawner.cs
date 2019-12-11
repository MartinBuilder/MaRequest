using System;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour {
    
    [SerializeField] private FallObject prefab;
    [SerializeField] private int size;

    public static Action<FallObject> FallObjectSpawned;

    public void SpawnObjects() {
        for (int i = -size / 2; i < size / 2; i++) {
            for (int j = 0; j < size; j++) {
                var clone = Instantiate(prefab, transform, false);
                var offset = (j % 2) * 0.3f;
                clone.transform.position += new Vector3(i + offset, j, 0);
                FallObjectSpawned.Invoke(clone);
            }
        }
    }

}
