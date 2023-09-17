using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour
{
    public AudioClip titleTheme;
    public AudioClip levelTheme;
    public AudioClip bossTheme;

    private AudioSource player;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
        player = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        Debug.Log("Scene Loaded: " + scene.name);
        if (scene.name == "Boss Level") {
            player.clip = bossTheme;
            player.Play();
        } else if (scene.name == "Credits") {
            player.clip = levelTheme;
            player.Play();
        }
    }
}
