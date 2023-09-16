using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AntPickupController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider2D collision){
        if(collision.transform.tag == "Player"){
            GameState.followerCount += 1;
            Debug.Log("Picked up an ant");
            gameObject.SetActive(false);

        }
    }
}
