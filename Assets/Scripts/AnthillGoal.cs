using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class AnthillGoal : MonoBehaviour
{
    //[SerializeField] String nextLevel; 
    // Start is called before the first frame update
    [SerializeField] GameObject Screen;
    [SerializeField] float delayLength = 2; 
    float timer;
    bool switching = false;
    void Start()
    {
        timer = delayLength;
        Screen = GameObject.FindGameObjectWithTag("Screen");
    }

    // Update is called once per frame
    void Update()
    {
        if(switching){
            timer -= Time.deltaTime;
            print(timer);
            //element transparancy
            //counts backwards so start and end are swapped
            byte alpha = (byte)Mathf.Lerp(255,0,timer/delayLength);
            UnityEngine.UI.Image image = Screen.GetComponent<UnityEngine.UI.Image>();
            image.color = new Color32(0,0,0,alpha);
        }

        if(timer < 0){
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

        }

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            print("Touched");
            
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //
            //LevelSwitcher switcher = GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelSwitcher>();
            print("Next Level!");
            //switcher.nextLevel();
            switching = true;
            
        }
    }
}
