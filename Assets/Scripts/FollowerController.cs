using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerController : MonoBehaviour
{
    public float moveSpeed = 1;
    public float maxSpeed = 3;
    GameObject player;
    Rigidbody2D rb;
    public Transform art;

    public float randomSpeed = 0.001f;

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

        // based on https://stackoverflow.com/questions/1768026/random-2d-movement-similar-to-flies-in-unity3d
        Vector3 randomDir = new Vector3(
            (float)((Random.value - 0.5) * randomSpeed),
            0,
            (float)((Random.value - 0.5) * randomSpeed)
        );
        rb.AddForce(randomDir);

        //taken from https://discussions.unity.com/t/lookat-2d-equivalent/88118
        //trig to point followers at the player
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        art.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

        // from https://stackoverflow.com/questions/48122532/how-to-set-maximum-velocity-of-a-rigidbody-in-unity
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
    }
    
}
