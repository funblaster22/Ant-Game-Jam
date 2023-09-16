using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraController : MonoBehaviour
{
     float currentSize;
     float targetSize;
    public float zoomSpeed = 0.5f;

    public float startingSize = 2;
    public float growSpeed = 0.1f;
    GameState gameState;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        gameState = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameState>();
        cam = Camera.main;
        currentSize = startingSize;
    }

    // Update is called once per frame
    void Update()
    {
        targetSize = gameState.FollowerCount * growSpeed + startingSize;
        
        currentSize += Mathf.Sign(targetSize - currentSize) * zoomSpeed *Time.deltaTime;
        cam.orthographicSize = currentSize;

    }



}
