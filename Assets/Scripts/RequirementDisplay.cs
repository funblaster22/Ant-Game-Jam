using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequirementDisplay : MonoBehaviour
{
    public int antsRequired = 1;
    public int distanceAway = 2;
    public GameObject display;

    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position - player.transform.position).magnitude <= distanceAway) {
            print("TOO CLOSE *blushes*");
            display.SetActive(true);
        } else {
            display.SetActive(false);
        }
    }
}
