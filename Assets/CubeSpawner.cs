using System;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour {
    
    [SerializeField] private FallObject prefab;

    public static CubeSpawner instance {
        get; private set;
    }

    private void OnEnable() {
        instance = this;
    }

    public static Action<FallObject> FallObjectSpawned;

    public void SpawnObjects(int width, int height, GenerationType generationType) {
        FallObjectManager.instance.DeleteAllSpawnedObjects();

        if (generationType == GenerationType.Jagged) {
            for (int i = -width / 2; i < width / 2; i++) {
                for (int j = 0; j < height; j++) {
                    var clone = Instantiate(prefab, transform, false);
                    var offset = (j % 2) * 0.3f;
                    clone.transform.position += new Vector3(i + offset, j, 0);
                    FallObjectSpawned.Invoke(clone);
                }
            }
        } else if (generationType == GenerationType.Square) {
            for (int i = 0; i < width; i++) {
                for (int j = 0; j < height; j++) {
                    var clone = Instantiate(prefab, transform, false);
                    clone.transform.position += new Vector3(i - width / 2, j, 0);
                    FallObjectSpawned.Invoke(clone);
                }
            }
        }

        
    }

}
