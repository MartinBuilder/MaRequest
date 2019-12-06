using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holder : MonoBehaviour {

    [SerializeField] private Rigidbody heldGO;
    public bool Holding { get; set; } = false;

    private Collider targetCollider;
    private Vector3 newPos = Vector3.zero;

    private void Update() {

        if (Holding) {
            heldGO.isKinematic = true;
            newPos = transform.position;
        } else {
            heldGO.isKinematic = false;
            heldGO = null;
        }
    }

    private void FixedUpdate() {
        heldGO?.MovePosition(newPos);
    }

    private void OnTriggerEnter(Collider other) {
        if (!Holding && other.tag == "cube" && other.GetComponent<Rigidbody>() != null) {
            heldGO = other.GetComponent<Rigidbody>();
            Holding = true;
        }
    }

}
