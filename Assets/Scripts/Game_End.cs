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

    public void Start()
    {
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

    //public void FixedUpdate(){
    //    if(scenef==108){
    //        SceneManager.LoadScene("Level_Selector");
    //        scenef=0;
    //        this.enabled=false;
    //    }
    //    else{
    //        scenef+=1;
    //    }
    //}
}
