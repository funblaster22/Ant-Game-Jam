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
    public List<AudioClip> eatingSounds;
    private AudioSource audioPlayer;
    void Start()
    {
        gameState = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameState>();
        audioPlayer = GetComponent<AudioSource>();
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
        if (!oncooldown) {
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
}
