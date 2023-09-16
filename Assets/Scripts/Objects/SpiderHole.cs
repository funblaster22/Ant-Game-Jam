using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderHole : MonoBehaviour
{
    // Start is called before the first frame update
    GameState gameState;
    [SerializeField] float cooldown = 1.0f;
    float currentTimer;

    bool oncooldown = false;
    void Start()
    {
        gameState = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameState>();

    }

    // Update is called once per frame
    void Update()
    {
        if(oncooldown){
            currentTimer += Time.deltaTime;
        }

        if(currentTimer > cooldown){
            oncooldown = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Follower")) {
            gameState.RemoveAnt(collision.gameObject);
            oncooldown = true;
            currentTimer = 0;
        }
        //else if (collision.gameObject.CompareTag("Player") && gameState.FollowerCount > antDeathNum) {
            //Die();
        //}
    }
}
