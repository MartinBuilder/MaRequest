using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SlingshotCenterPlane : MonoBehaviour
{
    public Action GameobjectEntering;

    private void OnTriggerEnter(Collider collision) {
        if (collision.tag == "Sphere") {
            GameobjectEntering?.Invoke();
        }
            
    }

}
