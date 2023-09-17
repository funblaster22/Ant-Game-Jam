using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AntPickupController : MonoBehaviour
{
    
    [SerializeField] float spinSpeed = 2;
    float speedOffsetMulti;
    float rotateDir;

    GameState gameState;
    // Start is called before the first frame update
    void Start()
    {
        gameState = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameState>();
        transform.Rotate(0,0, UnityEngine.Random.Range(0,360));
        speedOffsetMulti = UnityEngine.Random.Range(0.75f,1.25f);
        rotateDir =Mathf.Sign(UnityEngine.Random.Range(-1,1));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,spinSpeed*Time.deltaTime*50*speedOffsetMulti*rotateDir);
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player")){
            gameState.AddAnts(1);
            
            //destroy self
            Destroy(gameObject);
            
        }
    }
}
