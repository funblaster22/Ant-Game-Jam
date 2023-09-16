using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    //public  int FollowerCount => GameObject.FindGameObjectsWithTag("Follower").Length + 1;  // +1 to include the player

    public int FollowerCount = 0;
    public static int Points { get; set; } = 0;
    public static float TimeLeft { get; set; } = 100;

    public GameObject antFollower;
    private Boolean timerIsRunning = true;

    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //FollowerCount = GameObject.FindGameObjectsWithTag("Follower").Length + 1;

        // from https://gamedevbeginner.com/how-to-make-countdown-timer-in-unity-minutes-seconds/
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

    public void AddAnts(int num){
        FollowerCount += num;
        Instantiate(antFollower, player.transform.position, Quaternion.identity,transform);
        
    }

    public void RemoveAnts(int num){
        FollowerCount -= num;
        //destroy num ants
        //ants are only child for now

        for(int i = 0; i < num; i++){
            Destroy(transform.GetChild(i).gameObject);
        }
        
    }

    public void RemoveAnt(GameObject ant){
        FollowerCount -= 1;
        //Destroys the ant passed
        print("Eatin' an ant");
        Destroy(ant);
        
    }
}
