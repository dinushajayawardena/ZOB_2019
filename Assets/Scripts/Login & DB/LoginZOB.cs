
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class LoginZOB : MonoBehaviour
{
    public int updated_Score;

    public InputField username_InputField;
    public InputField password_InputField;
    public Text msg_Displayor;
    public Text command;

    public Button Loginbtn;
    public Button Resetbtn;

    void Start()
    {
        command.text = "Please Enter Valid Inputs to Continue";
        msg_Displayor.text = "Connecting to the Server....";
    }
    public void CallLogin()
    {
        StartCoroutine(LoginPlayer());
    }

    IEnumerator LoginPlayer()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username_InputField.text);
        form.AddField("password", password_InputField.text);

        WWW www = new WWW("http://localhost/sqlconnect/login.php", form);
        yield return www;

        if (www.text[0] == '0')
        {
            DBManagerZOB.name = www.text.Split('\t')[1];
            //DBManagerZOB.username = username_InputField.text;
            //DBManagerZOB.score = int.Parse(www.text.Split('\t')[1]);
            //updated_Score = DBManagerZOB.score;
            //print("Successfully connected");
            //EditorUtility.DisplayDialog("Login", "Login Successfully", "Ok");
            SceneManager.LoadScene(1);
            //print("Welcome " + DBManagerZOB.username + ". Your Score is " + DBManagerZOB.score);
        }
        else
        {
            EditorUtility.DisplayDialog("Login", "Login Failed!.Please Enter Valid Credentials", "Ok");
            command.text = "Please Enter Valid Inputs to Continue";
            command.color = new Color(255, 0, 0);
            //print("not connected" + www.text);
        }
    }

    public void VerifyInputs()
    {
        Loginbtn.interactable = (username_InputField.text.Length > 0 && password_InputField.text.Length > 0);

    }

    public void ClearInpts()
    {
        username_InputField.text = " ";
        password_InputField.text = " ";
    }
}
