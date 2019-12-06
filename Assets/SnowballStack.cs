using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballStack : MonoBehaviour {

    [SerializeField] private Rigidbody snowball;

    private Rigidbody storageSnowball;
    private Rigidbody current;

    private void Start() {
        SpawnSnowball();
    }

    private void OnTriggerStay(Collider other) {
        var currentHand = other?.GetComponent<Hand>();

        if (currentHand != null && currentHand.GetPinchDown()) {
            current = storageSnowball;
            current.isKinematic = false;

            SpawnSnowball();
        }

        
    }

    private void SpawnSnowball() {
        storageSnowball = Instantiate(snowball, transform);
        storageSnowball.isKinematic = true;
    }

}
