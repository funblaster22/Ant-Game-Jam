using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointBox : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI pointLabel;
    [SerializeField] GameState gameState;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pointLabel.text = "Points: " + gameState.Points;
        
    }
}
