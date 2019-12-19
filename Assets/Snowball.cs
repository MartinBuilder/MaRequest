using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour
{

    [SerializeField] private float timeBeforeKill = 5;
    private SnowballStack snowballStack;

    [SerializeField] public bool startCountdown = false;

    private void Start() {
        snowballStack = FindObjectOfType<SnowballStack>();
    }

    public float timeAlive {
        get; private set;
    }

    private void Update() {

        if (!startCountdown && transform.position.y < -10) {
            RemoveSnowball();
        }

        if (startCountdown) {
            timeAlive += Time.deltaTime;
            if (timeAlive > timeBeforeKill) {
                RemoveSnowball();
            }
        }
    }

    private void RemoveSnowball()
    {
        snowballStack.activeSnowballs.Remove(GetComponent<Rigidbody>());

        Destroy(gameObject);
    }

}
