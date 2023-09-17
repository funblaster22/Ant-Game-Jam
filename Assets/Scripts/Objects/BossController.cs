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

    [SerializeField] Sprite[] damageStates;
    [SerializeField] Animator animator;
    int accummulatedDamage = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        health -= dmg;
        accummulatedDamage += dmg;
        if(health <= 0){
            Die();
        }
        if(accummulatedDamage >= dmgToSpawn){
            //make spider
            print("Spider Time!");
            Instantiate(spider,transform.position,quaternion.identity,spiderstorage);
            //switch sprite
            accummulatedDamage -= dmgToSpawn;
            animator.SetTrigger("Damaged 1");
        }
    }

    void Die(){
        //deletes the spiders
        foreach (Transform child in spiderstorage) {
            Destroy(child.gameObject);
        }

        print("You defeated the boss!");


        //play win screen

    }
}
