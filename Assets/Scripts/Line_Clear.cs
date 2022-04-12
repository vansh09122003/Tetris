using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line_Clear : MonoBehaviour
{
    
    public GameObject[] anim;

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
}
