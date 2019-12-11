﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallObjectManager : MonoBehaviour
{
    private List<FallObject> spawnedFallObjects = new List<FallObject>();
    [SerializeField] private CubeSpawner cubeSpawner;

    private void Awake() {
        CubeSpawner.FallObjectSpawned += OnFallObjectSpawned;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            DeleteAllSpawnedObjects();
            cubeSpawner.SpawnObjects();
        }
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
