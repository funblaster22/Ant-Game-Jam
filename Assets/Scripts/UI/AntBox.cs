using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AntBox : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI timeLabel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeLabel.text = "Ants: " + GameState.FollowerCount;
    }
}
