using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class DBManagerZOB : MonoBehaviour
{
    public static string username;
    public static int score;
    public static string name;

    public static bool LoggedIn { get { return username != null; } }

    public void LogOut()
    {        
        bool option = EditorUtility.DisplayDialog("logout", "Are you sure want to Logout? ", "Ok", "Cancel");

        if(option)
        {
            username = null;
            SceneManager.LoadScene(0);
            print("username is " + username);
        }
        
    }
}
