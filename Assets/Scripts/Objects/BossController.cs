using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] GameObject spider;
    [SerializeField] int dmgToSpawn = 30;

    [SerializeField] Transform spiderstorage;

    [SerializeField] Animator animator;

    [SerializeField] GameObject antHill;
    int accummulatedDamage = 0;
    int spawnedSpiders = 0;
    bool won = false;
    [SerializeField]float timer = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(health <= 0){
            Die();
        }
        if(won){
            timer -= Time.deltaTime;
        }
        
        if(timer<0){
            //Instantiate(antHill,transform.position,quaternion.identity,spiderstorage);
            antHill.SetActive(true);
            transform.parent.GetComponent<SpiderHole>().enabled = false;
            enabled = false;
        }

        if(accummulatedDamage >= dmgToSpawn && !won && spawnedSpiders < 3){
            //make spider
            print("Spider Time!");
            Instantiate(spider,transform.position,quaternion.identity,spiderstorage);
            spawnedSpiders++;
            //switch sprite
            accummulatedDamage -= dmgToSpawn;
            animator.SetTrigger("Damaged 1");
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Food")){
            ObstacleController block = collision.gameObject.GetComponent<ObstacleController>();
            print("ouch");
            TakeDamage(block.antsRequired);
            Destroy(collision.gameObject);
        }
    }

    void TakeDamage(int dmg){
        //play sound effect
        GetComponent<AudioSource>().Play();
        health -= dmg;
        accummulatedDamage += dmg;
        if(health <= 0){
            Die();
        }
    }

    void Die(){
        //deletes the spiders
        foreach (Transform child in spiderstorage) {
            Destroy(child.gameObject);
        }

        print("You defeated the boss!");
        animator.SetTrigger("Explode");
        //play win screen
        won = true;
    }
}
