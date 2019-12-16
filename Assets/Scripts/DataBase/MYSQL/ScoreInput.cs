using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreInput : MonoBehaviour
{
    [SerializeField] private InputField Score;
    [SerializeField] private InputField Name;

    [SerializeField] private Button Submit;

    public void CallRegister()
    {
        StartCoroutine(Register());
    }

    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", Name.text);
        form.AddField("score", Score.text);
        WWW www = new WWW("http://25179.hosts.ma-cloud.nl/bewijzenmap/MaRequest/sqlconnect/register.php", form);
        yield return www;
        if(www.text == "0")
        {
            Debug.Log("New score created successfully.");
        }
        else
        {
            Debug.LogError("Registration of score failed. Error #" + www.text);
        }
    }

    public void VerifyInputs()
    {
        Submit.interactable = (Name.text.Length >= 3);
    }
}
