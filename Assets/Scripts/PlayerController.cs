using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10;
    public Camera cam;
    Rigidbody2D rb;
    public Transform art;

    

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
        Debug.Log(moveDir*moveSpeed);

        //taken from https://discussions.unity.com/t/lookat-2d-equivalent/88118
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        art.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        print("OH NO COLLISION!");
        if (collision.gameObject.CompareTag("Enemy"))
            Destroy(gameObject);
    }
}
