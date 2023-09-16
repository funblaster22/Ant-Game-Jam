using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public int antsRequired = 5;
    Rigidbody2D rb;

    GameState gameState;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //kinematic is static, non-dynamic
        rb.isKinematic = true;
        gameState = GameObject.FindGameObjectWithTag("GameConroller").GetComponent<GameState>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState.FollowerCount > antsRequired){
            rb.isKinematic = false;
        }
    }


}
