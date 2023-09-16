using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointBox : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI pointLabel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pointLabel.text = "Points: " + GameState.Points;
        
    }
}
