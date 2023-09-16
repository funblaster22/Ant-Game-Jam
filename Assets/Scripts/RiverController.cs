using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverController : MonoBehaviour
{
    public int antsRequired = 5;
    [SerializeField] GameObject finishedBridgeSprite;
    [SerializeField] GameObject waterSprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        //print($"You have {GameState.FollowerCount} ants, and I need {antsRequired} ants");
        if (collision.gameObject.CompareTag("Player") && GameState.FollowerCount >= antsRequired) {
            GetComponent<Collider2D>().enabled = false;
            var reqDisplay = GetComponent<RequirementDisplay>();
            reqDisplay.display.SetActive(false);


            finishedBridgeSprite.SetActive(true);
            waterSprite.SetActive(false);
            //Destroy(reqDisplay);

        }
    }
}
