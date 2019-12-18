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
    [SerializeField] private GameObject bandPrefab;
    [SerializeField] private float bandLength = 0;

    private GameObject bandLeft;
    private GameObject bandRight;

    public bool Holding { get; private set; } = false;

    private Vector3 newPos = Vector3.zero;
    private Quaternion newRot = Quaternion.identity;
    private Interactible myInteractible;
    private bool checkingForDistance = false;
    private Vector3 lastHandPos;

    private void Start() {
        myInteractible = GetComponent<Interactible>();

        Hand.HeldRb += OnHeldRb;
        Hand.ReleaseRb += OnReleaseRb;

        bandLeft = Instantiate(bandPrefab);
        bandRight = Instantiate(bandPrefab);
    }

    private void Update() {
        newPos = transform.position;
        newRot = transform.rotation;
        if (heldGO != null) {
            if (Holding) {
                heldGO.isKinematic = true;
            } else {
                heldGO.isKinematic = false;
                heldGO.velocity = GetComponent<Rigidbody>().velocity;
                heldGO.GetComponent<Snowball>().startCountdown = true;
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

        bandLeft.transform.position = Vector3.Lerp(transform.position, leftPos.position, 0.5f);
        bandRight.transform.position = Vector3.Lerp(transform.position, rightPos.position, 0.5f);

        Vector3 scale = bandLeft.transform.localScale;
        scale.y = Vector3.Distance(transform.position, leftPos.position) / 2 - bandLength;
        bandLeft.transform.localScale = scale;

        scale = bandLeft.transform.localScale;
        scale.y = Vector3.Distance(transform.position, rightPos.position) / 2 - bandLength;
        bandRight.transform.localScale = scale;

        bandLeft.transform.LookAt(transform);
        bandLeft.transform.eulerAngles += new Vector3(90, 0, 0);

        bandRight.transform.LookAt(transform);
        bandRight.transform.eulerAngles += new Vector3(-90, 0, 0);
    }

    public void ReleaseHeldGO() {
        Holding = false;
    }

    private void FixedUpdate() {
        
        heldGO?.MovePosition(newPos);
        heldGO?.MoveRotation(newRot);

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
