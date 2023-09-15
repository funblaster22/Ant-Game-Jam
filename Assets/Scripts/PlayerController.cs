using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveForce = 10;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = transform.GetComponent(Rigidbody);
    }

    // Update is called once per frame
    void Update()
    {
        //
        Vector3 moveDir = (transform.position - Camera.ScreenToWorldPoint(Input.mousePosition)).normalized;
        rb.addforce(moveDir*moveForce)
        

    }
}
