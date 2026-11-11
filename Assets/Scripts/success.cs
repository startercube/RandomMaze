using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class success : MonoBehaviour
{
    float timePlay;

    // Start is called before the first frame update
    void Start()
    {
        timePlay = PlayerPrefs.GetFloat("Playtime");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
    private void OnGUI()
    {
        GUI.Label(new Rect(20, Screen.height - 40, 128, 32), " Total Playtime:");
        GUI.Label(new Rect(120, Screen.height - 40, 128, 32), timePlay.ToString("F2")+"초");
    }
}
