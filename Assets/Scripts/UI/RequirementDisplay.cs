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
    private GameState gameState;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        gameState = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameState>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position - player.transform.position).magnitude <= distanceAway) {
            if (!display.activeSelf) {
                display.SetActive(true);
                var textComponent = display.GetComponent<TMP_Text>();
                textComponent.transform.position = transform.position;
                textComponent.text = $"{gameState.FollowerCount + 1}/{antsRequired + 1} Ants";
                textComponent.color = gameState.FollowerCount >= antsRequired ? Color.green : Color.red;
            }
        } else {
            display.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player") && gameState.FollowerCount >= antsRequired) {
            Destroy(gameObject);
        }
    }
}
