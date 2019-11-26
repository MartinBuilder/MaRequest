using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Launch : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float strength;
    [SerializeField] private Vector3 dir = new Vector3(0, 1, 1);

    private void Awake() {

        rb = GetComponent<Rigidbody>();

    }

    private void Start() {

        rb.AddForce(dir * strength);
        Debug.Log(rb is Rigidbody);
    }

    private void Something() {

    }


}