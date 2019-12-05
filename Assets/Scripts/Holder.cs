using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holder : MonoBehaviour {

    [SerializeField] private GameObject target;
    [SerializeField] private SlingshotCenterPlane slingshotCenter;
    public bool Holding { get; set; } = true;

    private Rigidbody targetRb;
    private Collider targetCollider;

    private void Awake() {
        targetRb = target.GetComponent<Rigidbody>();

        slingshotCenter.GameobjectEntering += OnGameObjectEntering;
    }

    private void FixedUpdate() {
        if (Holding) {
            targetRb.isKinematic = true;
            targetRb.MovePosition(transform.position);
        } else {
            targetRb.isKinematic = false;
        }
    }

    private void OnGameObjectEntering() {
        Holding = false;
    }

}
