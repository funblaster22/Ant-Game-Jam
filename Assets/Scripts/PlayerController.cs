using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static int followerCount = 1;

    public float moveForce = 10;
    public Camera cam;
    Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 moveDir = (transform.position - cam.ScreenToWorldPoint(Input.mousePosition)).normalized;
        rb.AddForce(moveDir*moveForce*Time.deltaTime);
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        print("OH NO COLLISION!");
        if (collision.gameObject.CompareTag("Enemy"))
            Destroy(gameObject);
    }
}
