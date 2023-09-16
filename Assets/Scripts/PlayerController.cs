using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float moveSpeed;

    [SerializeField] float deadzone = 5;
    [SerializeField] float walkSpeed = 10;
    [SerializeField] float runSpeed = 15;
    [SerializeField] float crawlSpeed = 1.0f;
    public Camera cam;
    Rigidbody2D rb;
    public Transform art;

    bool tryRunning = false;
    bool recovering = false;
    float stamina;
    [SerializeField] float recoverSpeed = 1.0f;
    [SerializeField] float maxStamina = 1.5f;
    
    //GameState gameState;

    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        //gameState = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameState>();

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Stamina is:" + stamina);
        //running logic (very messy and bad)
        Run();
        
        Vector2 moveDir = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        float cameraScale = CameraControler.cameraSize/2;
        if(moveDir.magnitude > deadzone*cameraScale ){
            rb.velocity = moveDir.normalized*moveSpeed;
        }else{
            //crawlzone
            //unnormalized for finetuned control
            //account for increasing camera size
            rb.velocity = moveDir*crawlSpeed/cameraScale;
        }
        
        Debug.Log(moveDir.magnitude);

        //taken from https://discussions.unity.com/t/lookat-2d-equivalent/88118
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        art.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

    }

    void Run(){
        if (Input.GetMouseButton(0) && !recovering){
            tryRunning = true;
        }
        else{
            tryRunning = false;
        }
        
        if(tryRunning){

            if( stamina > 0){
                moveSpeed = runSpeed;
                stamina -= Time.deltaTime;
            }else{
                //once running, can't try running again
                //Debug.Log("Recovering");
                recovering = true;
            }
        }
        else{
            moveSpeed = walkSpeed;
            if(stamina <= maxStamina){
                stamina += recoverSpeed*Time.deltaTime;
            }else{
                recovering = false;
            }
        }
    }


}
