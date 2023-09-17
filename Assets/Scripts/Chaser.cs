using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    public float maxSpeed = 2f;

    public int antDeathNum = 100;
    GameObject player;
    Rigidbody2D rb;
    [SerializeField] Transform art;

    GameState gameState;
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        gameState = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameState>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDir = Vector3.Normalize(player.transform.position - transform.position);
        rb.AddForce(moveDir*moveSpeed);
        //taken from https://discussions.unity.com/t/lookat-2d-equivalent/88118
        //trig to point followers at the player
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        //sprite is flipped by default
        art.rotation = Quaternion.Euler(0f, 0f, rot_z - 90 + 180);

        // from https://stackoverflow.com/questions/48122532/how-to-set-maximum-velocity-of-a-rigidbody-in-unity
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Follower")) {
            gameState.RemoveAnt(collision.gameObject);
        }else if (collision.gameObject.CompareTag("Player")) {
            if (gameState.FollowerCount > antDeathNum){
                Die();
            }else{
                print("You Lost");
                
            }
            
        }
    }

    void Die(){
        //replace sprite

        //disable logic
        enabled = false;
    }
}
