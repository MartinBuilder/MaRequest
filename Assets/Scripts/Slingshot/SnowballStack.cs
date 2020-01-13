using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SnowballStack : MonoBehaviour {

    [SerializeField] private Rigidbody snowball;
    [SerializeField] private int maxSnowballs = 5;
    private int currentSnowballs = 0;

    private Rigidbody storageSnowball;
    private bool entered = true;
    private bool canPickup = true;

    public List<Rigidbody> activeSnowballs;

    public Action<int> CurrentSnowballsChanged;
    public Action<Snowball> LastSnowball;

    private void Start() {
        activeSnowballs = new List<Rigidbody>();
        
        SpawnSnowball();
        
    }

    private void OnTriggerStay(Collider other) {
        var currentHand = other?.GetComponent<Hand>();

        if (canPickup && currentHand != null && currentHand.GetPinchDown() && entered) {
            storageSnowball.isKinematic = false;

            currentSnowballs++;
            CurrentSnowballsChanged?.Invoke(GetCurrentSnowballs());
            SpawnSnowball();
            entered = false;
        }

    }

    private void Update() {
        if(currentSnowballs >= maxSnowballs) {
            canPickup = false;
        }

        if(Input.GetKeyDown(KeyCode.T)) {
            currentSnowballs++;
            CurrentSnowballsChanged?.Invoke(GetCurrentSnowballs());
            SpawnSnowball();
        }
    }

    public void RefillStack() {
        canPickup = true;
        currentSnowballs = 0;
        CurrentSnowballsChanged?.Invoke(GetCurrentSnowballs());
    }

    public int GetMaxSnowballs() => maxSnowballs;
    public int GetCurrentSnowballs() => maxSnowballs - currentSnowballs;

    public bool SnowballsEmpty() => currentSnowballs >= maxSnowballs;
    public bool NoSnowballsActive() => activeSnowballs.Count == 1;

    private void OnTriggerExit(Collider other) {
        entered = true;
    }

    private void SpawnSnowball() {
        storageSnowball = Instantiate(snowball, transform);
        if (currentSnowballs == maxSnowballs - 1) {
            LastSnowball?.Invoke(storageSnowball.GetComponent<Snowball>());
        }

        activeSnowballs.Add(storageSnowball);
        storageSnowball.isKinematic = true;
    }

}
