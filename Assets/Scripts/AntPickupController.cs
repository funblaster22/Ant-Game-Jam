using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AntPickupController : MonoBehaviour
{
    
    [SerializeField] float spinSpeed = 2;

    GameState gameState;
    // Start is called before the first frame update
    void Start()
    {
        gameState = GameObject.FindGameObjectWithTag("GameConroller").GetComponent<GameState>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,spinSpeed);
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player")){
            gameState.AddAnts(1);
            
            //destroy self
            Destroy(gameObject);
            
        }
    }
}
