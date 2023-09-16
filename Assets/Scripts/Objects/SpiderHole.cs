using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderHole : MonoBehaviour
{
    // Start is called before the first frame update
    GameState gameState;

    void Start()
    {
        gameState = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameState>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Follower")) {
            gameState.RemoveAnt(collision.gameObject);
        }
        //else if (collision.gameObject.CompareTag("Player") && gameState.FollowerCount > antDeathNum) {
            //Die();
        //}
    }
}
