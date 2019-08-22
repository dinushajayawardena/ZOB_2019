using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTarget : MonoBehaviour
{
    float current_Score;
    // Start is called before the first frame update
    void Start()
    {
        current_Score = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        GetScore();
    }
    float GetScore()
    {
        return current_Score;
    }
}
