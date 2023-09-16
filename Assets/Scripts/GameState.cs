using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static int followerCount = 1;

    public int Points { get; set; } = 0;
    public float TimeLeft { get; set; } = 100;

    public Boolean timerIsRunning { get; set; } = true;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Points++;

        if (timerIsRunning)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");
                TimeLeft = 0;
                timerIsRunning = false;
            }
        }
    }
}
