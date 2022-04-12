using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_Screen : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetString("Top_1", "0");
        PlayerPrefs.SetString("Top_2", "0");
        PlayerPrefs.SetString("Top_3", "0");
        PlayerPrefs.SetString("Top_4", "0");
        PlayerPrefs.SetString("Top_5", "0");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Level_Selector");
        }
    }
}
