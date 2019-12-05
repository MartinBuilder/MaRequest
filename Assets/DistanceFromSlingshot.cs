using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceFromSlingshot : MonoBehaviour {

    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private float distance;
    [SerializeField] GameObject collider;

    private Vector3 center;

    private void Start() {
        center = Vector3.Lerp(pointA.position, pointB.position, 0.5f);
        
    }

    [SerializeField]private bool doThis = true;
    private void Update() {
        if (!doThis)
            return;

        if (Vector3.Distance(center, transform.position) > distance) {
            collider.SetActive(true);
            doThis = false;
        } else {
            collider.SetActive(false);
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.cyan;

        Gizmos.DrawWireSphere(transform.position, distance);
        Gizmos.DrawWireCube(center, Vector3.one / 10);
        
    }


}
