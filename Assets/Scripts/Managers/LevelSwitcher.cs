using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelSwitcher : MonoBehaviour
{
    [SerializeField] String[] sceneNames;
    public int currentLevelIndex = 0;
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
    }

    public void nextLevel(){
        //currentLevelIndex++;
        //SceneManager.LoadSceneAsync(sceneNames[currentLevelIndex]);

    }

    public void restartLevel(){
        //currentLevelIndex++;
        print("restarted current level");
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);

    }

    
}
