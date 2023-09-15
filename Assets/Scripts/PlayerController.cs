using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10;
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
        
        Vector3 moveDir = Vector3.Normalize(cam.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        rb.velocity = moveDir*moveSpeed;

        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        print("OH NO COLLISION!");
        if (collision.gameObject.CompareTag("Enemy"))
            Destroy(gameObject);
    }
}
