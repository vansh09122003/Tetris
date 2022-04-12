using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn : MonoBehaviour
{

    public GameObject[] pieces;
    public int r = 0;
    public int next,curr;

    public GameObject I;
    public GameObject J;
    public GameObject L;
    public GameObject O;
    public GameObject S;
    public GameObject T;
    public GameObject Z;

    public Text i_count;
    public Text j_count;
    public Text l_count;
    public Text o_count;
    public Text s_count;
    public Text t_count;
    public Text z_count;

    public int drt;

    public Text drought;

    
    void Start()
    {
        i_count = GameObject.Find("i_count").GetComponent<Text>();
        j_count = GameObject.Find("j_count").GetComponent<Text>();
        l_count = GameObject.Find("l_count").GetComponent<Text>();
        o_count = GameObject.Find("o_count").GetComponent<Text>();
        s_count = GameObject.Find("s_count").GetComponent<Text>();
        t_count = GameObject.Find("t_count").GetComponent<Text>();
        z_count = GameObject.Find("z_count").GetComponent<Text>();

        drought = GameObject.Find("drt_count").GetComponent<Text>();
        spawn();
    }

    public void spawn()
    {
        if (r == 0)
        {
            curr = Random.Range(0, pieces.Length);
            rand();
            Instantiate(pieces[curr], transform.position, Quaternion.identity);
            r += 1;
        }
        else
        {
            curr = next;
            rand();
            Instantiate(pieces[curr], transform.position, Quaternion.identity);
        }

        if (curr == 0)
        {
            i_count.text = (System.Convert.ToInt32(i_count.text) + 1).ToString();
            drt = 0;
            PlayerPrefs.SetString("I", i_count.text);
        }
        else if (curr == 1)
        {
            j_count.text = (System.Convert.ToInt32(j_count.text) + 1).ToString();
            drt += 1;
            PlayerPrefs.SetString("J", j_count.text);
        }
        else if (curr == 2)
        {
            l_count.text = (System.Convert.ToInt32(l_count.text) + 1).ToString();
            drt += 1;
            PlayerPrefs.SetString("L", l_count.text);
        }
        else if (curr == 3)
        {
            o_count.text = (System.Convert.ToInt32(o_count.text) + 1).ToString();
            drt += 1;
            PlayerPrefs.SetString("O", o_count.text);
        }
        else if (curr == 4)
        {
            s_count.text = (System.Convert.ToInt32(s_count.text) + 1).ToString();
            drt += 1;
            PlayerPrefs.SetString("S", s_count.text);
        }
        else if (curr == 5)
        {
            t_count.text = (System.Convert.ToInt32(t_count.text) + 1).ToString();
            drt += 1;
            PlayerPrefs.SetString("T", t_count.text);
        }
        else if (curr == 6)
        {
            z_count.text = (System.Convert.ToInt32(z_count.text) + 1).ToString();
            drt += 1;
            PlayerPrefs.SetString("Z", z_count.text);
        }

        drought.text = drt.ToString();
        if(System.Convert.ToInt32(drought.text) > System.Convert.ToInt32(PlayerPrefs.GetString("M_Drought")))
        {
            PlayerPrefs.SetString("M_Drought", drought.text);
        }
    }

    public void rand()
    {
        next = Random.Range(0, pieces.Length);

        I.SetActive(false);
        J.SetActive(false);
        L.SetActive(false);
        O.SetActive(false);
        S.SetActive(false);
        T.SetActive(false);
        Z.SetActive(false);

        if (next == 0)
        {
            I.SetActive(true);
        }
        else if (next == 1)
        {
            J.SetActive(true);
        }
        else if (next == 2)
        {
            L.SetActive(true);
        }
        else if (next == 3)
        {
            O.SetActive(true);
        }
        else if (next == 4)
        {
            S.SetActive(true);
        }
        else if (next == 5)
        {
            T.SetActive(true);
        }
        else if (next == 6)
        {
            Z.SetActive(true);
        }
    }
}
