using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelSwitcher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)){
            restartLevel();
        }
        if (Input.GetKeyDown(KeyCode.N)) {
            nextLevel();
        }
    }

    public void nextLevel(){
        // Most level switching is handled by AnthillGoal.cs, this is primarily for title screen
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public static void restartLevel(){
        //currentLevelIndex++;
        print("restarted current level");
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);

    }

    
}
