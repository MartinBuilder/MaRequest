using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballStack : MonoBehaviour {

    [SerializeField] private Rigidbody snowball;

    private Rigidbody storageSnowball;
    private bool pickedUp = true;

    private void Start() {
        SpawnSnowball();
    }

    private void OnTriggerStay(Collider other) {
        var currentHand = other?.GetComponent<Hand>();

        if (currentHand != null && currentHand.GetPinchDown() && pickedUp) {
            storageSnowball.isKinematic = false;

            SpawnSnowball();
            pickedUp = false;
        }

        
    }

    private void OnTriggerExit(Collider other) {
        pickedUp = true;
    }

    private void SpawnSnowball() {
        storageSnowball = Instantiate(snowball, transform);
        storageSnowball.isKinematic = true;
    }

}
