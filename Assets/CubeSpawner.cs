using System;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour {
    
    [SerializeField] private FallObject prefab;

    public static Action<FallObject> FallObjectSpawned;

    public void SpawnObjects(int width, int height) {
        for (int i = -width / 2; i < width / 2; i++) {
            for (int j = 0; j < height; j++) {
                var clone = Instantiate(prefab, transform, false);
                var offset = (j % 2) * 0.3f;
                clone.transform.position += new Vector3(i + offset, j, 0);
                FallObjectSpawned.Invoke(clone);
            }
        }
    }

}
