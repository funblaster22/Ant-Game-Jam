using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public int antsRequired = 5;
    Rigidbody2D rb;

    GameState gameState;
    private float distanceMoved = walkSoundDistance - 0.1f;
    private const float walkSoundDistance = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //kinematic is static, non-dynamic
        rb.isKinematic = true;
        gameState = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameState>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState.FollowerCount >= antsRequired){
            rb.isKinematic = false;
        }else{
            rb.isKinematic = true;
        }

        // Play a step sound after an ant has walked a certain distance
        distanceMoved += rb.velocity.magnitude * Time.deltaTime;
        if (distanceMoved > walkSoundDistance) {
            GetComponent<AudioSource>().Play();
            distanceMoved = 0;
        }
    }


}
