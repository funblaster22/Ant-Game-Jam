using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverController : MonoBehaviour
{
    public int antsRequired = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        print($"You have {GameState.FollowerCount}, and I need {antsRequired}");
        if (collision.gameObject.CompareTag("Player") && GameState.FollowerCount >= antsRequired) {
            Destroy(GetComponent<Collider2D>());
            var reqDisplay = GetComponent<RequirementDisplay>();
            reqDisplay.display.SetActive(false);
            Destroy(reqDisplay);

        }
    }
}
