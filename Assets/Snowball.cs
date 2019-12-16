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

        if (transform.position.y < -10) {
            startCountdown = true;
        }

        if (startCountdown) {
            timeAlive += Time.deltaTime;
            if (timeAlive > timeBeforeKill) {
                snowballStack.activeSnowballs.Remove(GetComponent<Rigidbody>());

                Destroy(gameObject);
            }
        }
    }

}
