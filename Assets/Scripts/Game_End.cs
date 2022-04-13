using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class Game_End : MonoBehaviour
{
    //public AnimationClip[] end_animation;
    //public Animation End_Animation;

    public GameObject[] anim;
    public int scenef=0;
    public GameObject game_end;

    public void Start()
    {
        game_end.SetActive(true);
        for (int i = 0; i < 16; i++)
        {
            anim[i].SetActive(true);
        }
        StartCoroutine(end());
    }
    IEnumerator end(){
        yield return new WaitForSeconds(2.417f);
        SceneManager.LoadScene("Level_Selector");
    }
}
