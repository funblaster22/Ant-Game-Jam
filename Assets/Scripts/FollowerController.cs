using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float maxSpeed = 3f;
    public float maxForce = 1f;

    GameObject player;
    Rigidbody2D rb;
    public Transform art;

    public float randomSpeed = 1f;

    private static List<FollowerController> followers = new List<FollowerController>();

    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        followers.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Vector3 moveDir = Vector3.Normalize(player.transform.position - transform.position);
        rb.AddForce(moveDir*moveSpeed);

        */

        swarm();
        
        /*
        // based on https://stackoverflow.com/questions/1768026/random-2d-movement-similar-to-flies-in-unity3d
        Vector3 randomDir = new Vector3(
            (float)((Random.value - 0.5) * randomSpeed),
            0,
            (float)((Random.value - 0.5) * randomSpeed)
        );
        rb.AddForce(randomDir);
        */
        //taken from https://discussions.unity.com/t/lookat-2d-equivalent/88118
        //trig to point followers at the player
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        art.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

        // from https://stackoverflow.com/questions/48122532/how-to-set-maximum-velocity-of-a-rigidbody-in-unity
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Enemy"))
            Destroy(gameObject);
    }

    void OnDestroy()
    {
        followers.Remove(this);
    }

    /* Swarm boid movement */

    // We accumulate a new acceleration each time based on three rules
    void swarm()
    {
        Vector3 sep = separate(followers);   // Separation
        Vector3 ali = align(followers);      // Alignment
        Vector3 coh = cohesion(followers);   // Cohesion
        Vector3 seekVector = seek(player.transform.position);

        // Arbitrarily weight these forces
        sep = sep * 1f;
        ali = ali * 0.5f;
        coh = coh * 0.2f;
        seekVector *= 2f;

        // Add the force vectors to acceleration
        rb.AddForce(sep);
        rb.AddForce(ali);
        rb.AddForce(coh);
        rb.AddForce(seekVector);
    }

    // A method that calculates and applies a steering force towards a target
    // STEER = DESIRED MINUS VELOCITY
    Vector3 seek(Vector3 target)
    {
        Vector3 desired = target - transform.position;  // A vector pointing from the position to the target
                                                          // Scale to maximum speed
        desired.Normalize();
        desired = desired * maxSpeed;

        // Above two lines of code below could be condensed with new Vector3 setMag() method
        // Not using this method until Processing.js catches up
        // desired.setMag(maxSpeed);

        // Steering = Desired minus Velocity
        Vector3 steer = desired - (Vector3) (rb.velocity);
        steer = Vector3.ClampMagnitude(steer, maxForce);  // Limit to maximum steering force
        return steer;
    }

    // Separation
    // Method checks for nearby boids and steers away
    Vector3 separate(List<FollowerController> followers)
    {
        float desiredseparation = 25.0f;
        Vector3 steer = new Vector3(0, 0, 0);
        int count = 0;
        // For every boid in the system, check if it's too close
        foreach (FollowerController other in followers)
        {
            float d = Vector3.Distance(transform.position, other.transform.position);
            // If the distance is greater than 0 and less than an arbitrary amount (0 when you are yourself)
            if ((d > 0) && (d < desiredseparation))
            {
                // Calculate vector pointing away from neighbor
                Vector3 diff = transform.position - other.transform.position;
                diff.Normalize();
                diff /= d;        // Weight by distance
                steer += diff;
                count++;            // Keep track of how many
            }
        }
        // Average -- divide by how many
        if (count > 0)
        {
            steer /= (float)count;
        }

        // As long as the vector is greater than 0
        if (steer.magnitude > 0)
        {
            // First two lines of code below could be condensed with new Vector3 setMag() method
            // Not using this method until Processing.js catches up
            // steer.setMag(maxSpeed);

            // Implement Reynolds: Steering = Desired - Velocity
            steer.Normalize();
            steer = steer * maxSpeed;
            steer -= (Vector3) (rb.velocity);
            steer = Vector3.ClampMagnitude(steer, maxForce);
        }
        return steer;
    }

    // Alignment
    // For every nearby boid in the system, calculate the average velocity
    Vector3 align(List<FollowerController> followers)
    {
        float neighbordist = 50;
        Vector3 sum = new Vector3(0, 0, 0);
        int count = 0;
        foreach (FollowerController other in followers)
        {
            float d = Vector3.Distance(transform.position, other.transform.position);
            if ((d > 0) && (d < neighbordist))
            {
                sum += (Vector3) (other.rb.velocity);
                count++;
            }
        }
        if (count > 0)
        {
            sum /= (float)count;
            // First two lines of code below could be condensed with new Vector3 setMag() method
            // Not using this method until Processing.js catches up
            // sum.setMag(maxSpeed);

            // Implement Reynolds: Steering = Desired - Velocity
            sum.Normalize();
            sum = sum * maxSpeed;
            Vector3 steer = sum - (Vector3) (rb.velocity);
            steer = Vector3.ClampMagnitude(steer, maxForce);
            return steer;
        }
        else
        {
            return new Vector3(0, 0, 0);
        }
    }

    // Cohesion
    // For the average position (i.e. center) of all nearby boids, calculate steering vector towards that position
    Vector3 cohesion(List<FollowerController> followers)
    {
        float neighbordist = 50;
        Vector3 sum = new Vector3(0, 0, 0);   // Start with empty vector to accumulate all positions
        int count = 0;
        foreach (FollowerController other in followers)
        {
            float d = Vector3.Distance(transform.position, other.transform.position);
            if ((d > 0) && (d < neighbordist))
            {
                sum += other.transform.position; // Add position
                count++;
            }
        }
        if (count > 0)
        {
            sum /= count;
            return seek(sum);  // Steer towards the position
        }
        else
        {
            return new Vector3(0, 0, 0);
        }
    }
}
