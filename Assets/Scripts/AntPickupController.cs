using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AntPickupController : MonoBehaviour
{
    public GameObject antFollower;
    [SerializeField] float spinSpeed = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,spinSpeed);
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player")){
            Destroy(gameObject);
            Instantiate(antFollower, transform.position, Quaternion.identity);
        }
    }
}
