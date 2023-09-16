using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AnthillGoal : MonoBehaviour
{
    [SerializeField] String nextLevel; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //
            //LevelSwitcher switcher = GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelSwitcher>();
            print("Next Level!");
            //switcher.nextLevel();
            SceneManager.LoadSceneAsync(nextLevel);
            
        }
    }
}
