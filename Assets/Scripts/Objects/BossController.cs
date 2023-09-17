using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] float health = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Food")){
            TakeDamage(1);
            Destroy(collision.gameObject);
        }
    }

    void TakeDamage(int dmg){
        //play sound effect
        health -= dmg;
        if(health <= 0){
            Die();
        }
    }

    void Die(){
        print("You defeated the boss!");
        //play win screen

    }
}
