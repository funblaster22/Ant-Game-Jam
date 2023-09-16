using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public int followerCount = 1;

    public int Points { get; set; }
    public int TimeLeft { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        TimeLeft = 0;    
    }

    // Update is called once per frame
    void Update()
    {
        Points++;    
    }
}
