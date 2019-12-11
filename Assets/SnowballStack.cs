using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballStack : MonoBehaviour {

    [SerializeField] private Rigidbody snowball;
    [SerializeField] private int maxSnowballs = 5;
    private int currentSnowballs = 0;

    private Rigidbody storageSnowball;
    private bool entered = true;
    private bool canPickup = true;

    private void Start() {
        SpawnSnowball();
    }

    private void OnTriggerStay(Collider other) {
        var currentHand = other?.GetComponent<Hand>();

        if (canPickup && currentHand != null && currentHand.GetPinchDown() && entered) {
            storageSnowball.isKinematic = false;

            currentSnowballs++;
            SpawnSnowball();
            entered = false;
        }

        
    }

    private void Update() {
        if(currentSnowballs >= maxSnowballs) {
            canPickup = false;
        }
    }

    public void RefillStack() {
        canPickup = true;
        currentSnowballs = 0;
    }

    private void OnTriggerExit(Collider other) {
        entered = true;
    }

    private void SpawnSnowball() {
        storageSnowball = Instantiate(snowball, transform);
        storageSnowball.isKinematic = true;
    }

}
