using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] float health = 100;
    [SerializeField] GameObject spider;
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
        if(accummulatedDamage >= 50){
            //make spider
            print("Spider Time!");
            Instantiate(spider,transform.position,quaternion.identity);
            accummulatedDamage -= 50;
        }
    }

    void Die(){
        print("You defeated the boss!");
        //play win screen

    }
}
