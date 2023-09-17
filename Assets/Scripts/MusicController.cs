using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour
{
    public AudioClip titleTheme;
    public AudioClip levelTheme;
    public AudioClip bossTheme;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);
    }
}
