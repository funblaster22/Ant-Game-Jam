using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AntBox : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI timeLabel;
    GameState gameState;
    // Start is called before the first frame update
    void Start()
    {
        gameState = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameState>();
    }

    // Update is called once per frame
    void Update()
    {
        timeLabel.text = "Ants: " + gameState.FollowerCount;
    }
}
