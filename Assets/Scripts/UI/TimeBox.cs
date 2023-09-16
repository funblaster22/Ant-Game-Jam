using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeBox : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeLabel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeLabel.text = "Time: " + GameState.TimeLeft.ToString("0.0");
        
    }
}
