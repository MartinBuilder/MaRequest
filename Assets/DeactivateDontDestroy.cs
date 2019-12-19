using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class DeactivateDontDestroy : MonoBehaviour
{
    SteamVR_Behaviour behaviour;

    private void Awake()
    {
        behaviour = FindObjectOfType<SteamVR_Behaviour>();
        behaviour.doNotDestroy = false;
    }
}
