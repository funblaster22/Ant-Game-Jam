using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeBox : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeLabel;
    [SerializeField] GameState gameState;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeLabel.text = "Points: " + gameState.TimeLeft;
        
    }
}
