using System;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour {
    
    [SerializeField] private FallObject prefab;
    [SerializeField] private Vector3 startPos;

    public static CubeSpawner instance {
        get; private set;
    }

    private void OnEnable() {
        instance = this;
    }

    public static Action<FallObject> FallObjectSpawned;

    public void SpawnObjects(int width, int height, GenerationType generationType, Vector3 size) {
        FallObjectManager.instance.DeleteAllSpawnedObjects();
        transform.position = startPos + new Vector3(0, size.y / 2, 0);

        if (generationType == GenerationType.Jagged) {
            for (int i = 0; i < width; i++) {
                for (int j = 0; j < height; j++) {
                    var clone = Instantiate(prefab, transform, false);
                    var offset = (j % 2) * 0.3f;
                    clone.transform.position += new Vector3((i - width / 2 + offset) * size.x, j * size.y, 0);
                    clone.transform.localScale = size;
                    FallObjectSpawned.Invoke(clone);
                }
            }
        } else if (generationType == GenerationType.Square) {
            for (int i = 0; i < width; i++) {
                for (int j = 0; j < height; j++) {
                    var clone = Instantiate(prefab, transform, false);
                    clone.transform.position += new Vector3((i - width / 2) * size.x, j * size.y, 0);
                    clone.transform.localScale = size;
                    FallObjectSpawned.Invoke(clone);
                }
            }
        }

        
    }

}
