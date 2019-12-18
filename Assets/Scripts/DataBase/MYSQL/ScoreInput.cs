using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreInput : MonoBehaviour {

    [SerializeField] TextMeshProUGUI nameLabel;

    private Action<bool> FinishedRegistration;

    private void Awake()
    {
        FinishedRegistration += OnRegistrationFinished;
    }

    public void InputScore() {
        CallRegister(nameLabel.text, ScoreManager.Score);
    }

    private void CallRegister(string name, int score)
    {

        if (name == string.Empty) {
            FinishedRegistration.Invoke(true);
        }

        StartCoroutine(Register(name, score));
    }

    IEnumerator Register(string name, int score)
    {
        WWWForm form = new WWWForm();
        form.AddField("name", name);
        form.AddField("score", score);
        WWW www = new WWW("http://25179.hosts.ma-cloud.nl/bewijzenmap/MaRequest/sqlconnect/register.php", form);
        yield return www;
        if(www.text == "0")
        {
            Debug.Log("New score created successfully.");
            FinishedRegistration?.Invoke(true);
        }
        else
        {
            Debug.LogError("Registration of score failed. Error #" + www.text);
            FinishedRegistration?.Invoke(false);
        }
    }

    private void OnRegistrationFinished(bool succes)
    {
        if(succes)
        {
            SceneManager.LoadScene(1);
        }
    }

}
