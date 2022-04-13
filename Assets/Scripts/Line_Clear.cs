using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line_Clear : MonoBehaviour
{
    
    public GameObject[] anim;
    public GameObject[] sounds;

    public void line_clear(int line_no){
        anim[line_no].SetActive(true);
        Animator an =anim[line_no].GetComponent<Animator>();
        an.speed=10f;
        StartCoroutine(deactivate(line_no));
    }

    IEnumerator deactivate(int line_no){
        yield return new WaitForSeconds(0.2417f);
        Animator an =anim[line_no].GetComponent<Animator>();
        an.speed=1f;
        anim[line_no].SetActive(false);
    }

    public void lin(){
        sounds[0].SetActive(true);
        StartCoroutine(sound_deactivate());
    }
    IEnumerator sound_deactivate(){
        yield return new WaitForSeconds(1f);
        sounds[1].SetActive(false);
        sounds[0].SetActive(false);
    }
    public void tet(){
        sounds[1].SetActive(true);
        StartCoroutine(sound_deactivate());
    }

    public void add_board(){
        sounds[2].SetActive(true);
        StartCoroutine(board_sound_deactivate());
    }

    IEnumerator board_sound_deactivate(){
        yield return new WaitForSeconds(0.2f);
        sounds[2].SetActive(false);
    }

}
