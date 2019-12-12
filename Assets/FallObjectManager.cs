using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallObjectManager : MonoBehaviour {
    private List<FallObject> spawnedFallObjects = new List<FallObject>();

    public static FallObjectManager instance {
        get; private set;
    }

    private void OnEnable() {
        instance = this;
    }

    private void Awake() {
        CubeSpawner.FallObjectSpawned += OnFallObjectSpawned;
    }

    public void DeleteAllSpawnedObjects() {
        foreach (FallObject fallObject in spawnedFallObjects) {
            Destroy(fallObject.gameObject);
        }

        spawnedFallObjects.Clear();
    }

    private void OnFallObjectSpawned(FallObject fallObject) {
        spawnedFallObjects.Add(fallObject);
    }

}

