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
    [SerializeField] List<AudioClip> eatingSounds;
    private AudioSource audioPlayer;

    GameState gameState;
    [SerializeField] float cooldown = 1.0f;
    float currentTimer;
    bool oncooldown = false;

    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        gameState = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameState>();
        audioPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if(oncooldown){
            currentTimer += Time.deltaTime;
        }

        if(currentTimer > cooldown){
            oncooldown = false;
        }
    }
    

    private void OnCollisionEnter2D(Collision2D collision) {
        if (!oncooldown){
            // TODO: reduce code duplication between this & SpiderHole
            audioPlayer.clip = eatingSounds[Random.Range(0, eatingSounds.Count)];
            if (collision.gameObject.CompareTag("Follower") ){
                gameState.RemoveAnt(collision.gameObject);
                oncooldown = true;
                currentTimer = 0;
                audioPlayer.Play();
            } else if (collision.gameObject.CompareTag("Player") && gameState.FollowerCount == 0){
                LevelSwitcher.restartLevel();
                audioPlayer.Play();
            }

        }
    }

    void Move(){
        Vector3 moveDir = Vector3.Normalize(player.transform.position - transform.position);
        rb.AddForce(moveDir*moveSpeed);
        //taken from https://discussions.unity.com/t/lookat-2d-equivalent/88118
        //trig to point followers at the player
        Vector3 diff = player.transform.position - transform.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        //sprite is flipped by default
        art.rotation = Quaternion.Euler(0f, 0f, rot_z - 90 + 180);
        // from https://stackoverflow.com/questions/48122532/how-to-set-maximum-velocity-of-a-rigidbody-in-unity
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
    }
    void Die(){
        //replace sprite

        //disable logic
        enabled = false;
    }

}
