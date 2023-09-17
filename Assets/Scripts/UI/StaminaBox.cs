using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaBox : MonoBehaviour
{
    private PlayerController player;
    private RectTransform rectTransform;
    private const float maxWidth = 150;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.sizeDelta = new Vector2(maxWidth * (player.stamina / player.maxStamina), rectTransform.sizeDelta.y);
    }
}
