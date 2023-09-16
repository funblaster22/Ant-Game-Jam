using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AntPickupController : MonoBehaviour
{
    public GameObject antFollower;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player")){
            Destroy(gameObject);
            Instantiate(antFollower, transform.position, Quaternion.identity);
        }
    }
}
