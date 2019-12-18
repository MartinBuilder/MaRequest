using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SnowballStackUI : MonoBehaviour {

    [SerializeField] private Image frontImage;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private SnowballStack snowballStack;
    [SerializeField] private float fillSpeed = 5;

    private float targetFillAmount = 1;
    private float currentFillAmount = 1;

    private Snowball lastSnowball;

    private void Awake() {
        snowballStack.CurrentSnowballsChanged += OnCurrentSnowBallsChanged;
        snowballStack.LastSnowball += OnLastSnowball;
    }

    private void Update() {
        currentFillAmount = Mathf.Lerp(currentFillAmount, targetFillAmount, Time.deltaTime * fillSpeed);
        frontImage.fillAmount = currentFillAmount;

        if((bool) lastSnowball?.startCountdown) {
            // TO DO    calculate time for countdown
        }
    }

    private void OnCurrentSnowBallsChanged(int currentAmount) {
        text.text = snowballStack.GetCurrentSnowballs() + "/ " + snowballStack.GetMaxSnowballs();
        targetFillAmount = MapFillAmount(snowballStack.GetCurrentSnowballs(), snowballStack.GetMaxSnowballs(), 0);
    }

    private void OnLastSnowball(Snowball snowball) {
        lastSnowball = snowball;
    }

    private float MapFillAmount(float value, float max, float min) {
        return (value - min) / (max - min);
    }

}
