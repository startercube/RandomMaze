using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startgame : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            
            SceneManager.LoadScene(Random.Range(1,4));
            
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            
            PlayerPrefs.SetFloat("Playtime", 0.0f);
            PlayerPrefs.SetInt("gameloop", 0);
            SceneManager.LoadScene(Random.Range(1, 4));

        }

    }
       
}
