using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerController : MonoBehaviour
{
    public float moveSpeed = 10;
    GameObject player;
    Rigidbody2D rb;
    public Transform art;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
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
        art.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }
    
}
