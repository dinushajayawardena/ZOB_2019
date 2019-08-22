using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuZOB : MonoBehaviour
{
    public Text welcome_Msg;

    void Start()
    {
        welcome_Msg.text = "Welcome " + DBManagerZOB.username;
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(2);
    }
}
