using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverController : MonoBehaviour
{
    public int antsRequired = 5;
    [SerializeField] GameObject finishedBridgeSprite;
    //[SerializeField] GameObject waterSprite;

    GameState gameState;
    // Start is called before the first frame update
    void Start()
    {
        gameState = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameState>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        //print($"You have {GameState.FollowerCount} ants, and I need {antsRequired} ants");
        if (collision.gameObject.CompareTag("Player") && gameState.FollowerCount >= antsRequired) {
            GetComponent<Collider2D>().enabled = false;


            finishedBridgeSprite.SetActive(true);

            //waterSprite.SetActive(false);
            //can't destroy the player
            gameState.RemoveAnts(antsRequired);
            //Destroy(reqDisplay);

            GetComponent<AudioSource>().Play();
        }
    }
}
