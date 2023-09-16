using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointBox : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI pointLabel;
    //GameState gameState;
    // Start is called before the first frame update
    void Start()
    {
        //gameState = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameState>();

    }

    // Update is called once per frame
    void Update()
    {
        pointLabel.text = "Points: " + GameState.Points;
        
    }
}
