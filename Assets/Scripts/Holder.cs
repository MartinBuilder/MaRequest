using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactible))]
public class Holder : MonoBehaviour {

    public Rigidbody heldGO {
        get; private set;
    }

    [SerializeField] private Transform center;
    [SerializeField] private Transform leftPos;
    [SerializeField] private Transform rightPos;

    public bool Holding { get; private set; } = false;

    private Vector3 newPos = Vector3.zero;
    private Interactible myInteractible;
    private bool checkingForDistance = false;
    private Vector3 lastHandPos;

    private void Start() {
        myInteractible = GetComponent<Interactible>();

        Hand.HeldRb += OnHeldRb;
        Hand.ReleaseRb += OnReleaseRb;
    }

    private void Update() {
        if (heldGO != null) {
            if (Holding) {
                heldGO.isKinematic = true;
                newPos = transform.position;
            } else {
                heldGO.isKinematic = false;
                heldGO.velocity = GetComponent<Rigidbody>().velocity;
                heldGO = null;
            }
        }

        if (heldGO == null && transform.position.z < center.position.z) {

            GetComponent<BoxCollider>().enabled = true;
        }

        if (checkingForDistance) {
            if (Vector3.Distance(transform.position, lastHandPos) > 0.7) {

                GetComponent<BoxCollider>().enabled = false;
                checkingForDistance = false;
            }
        }
    }

    public void ReleaseHeldGO() {
        Holding = false;
    }

    private void FixedUpdate() {
        heldGO?.MovePosition(newPos);

        if (heldGO?.position.z > center.position.z + .2f && heldGO?.position.z < center.position.z + 3f) {
            ReleaseHeldGO();
        }

    }

    private void OnTriggerEnter(Collider other) {
        if (!Holding && other.tag == "cube" && other.GetComponent<Rigidbody>() != null) {
            heldGO = other.GetComponent<Rigidbody>();
            Holding = true;
            other.GetComponent<Interactible>().Enabled = false;
        }
    }

    private void OnHeldRb(Rigidbody rb) {
        
    }

    private void OnReleaseRb(Rigidbody rb) {

        if (rb == GetComponent<Rigidbody>() && Vector3.Distance(transform.position, Vector3.Lerp(leftPos.position, rightPos.position, 0.5f)) > 1) {
            checkingForDistance = true;
            
            lastHandPos = myInteractible.m_activeHand.transform.position;
        }
    }

}
