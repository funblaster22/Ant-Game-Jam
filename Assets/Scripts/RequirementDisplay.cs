using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
            if (!display.activeSelf) {
                display.SetActive(true);
                var textComponent = display.GetComponent<TMP_Text>();
                textComponent.transform.position = transform.position;
                textComponent.text = $"{GameState.FollowerCount}/{antsRequired} Ants";
                textComponent.color = GameState.FollowerCount >= antsRequired ? Color.green : Color.red;
            }
        } else {
            display.SetActive(false);
        }
    }
}
