using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    private Camera _camera;
    //default 2, expands with higher followers
    public static float cameraSize;
    public float startingSize = 2;
    public float growSpeed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        cameraSize = (GameState.FollowerCount - 1) * growSpeed + startingSize;
        _camera.orthographicSize = cameraSize;
    }
}
