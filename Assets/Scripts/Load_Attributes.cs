using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Load_Attributes : MonoBehaviour
{

    public Text i_count;
    public Text j_count;
    public Text l_count;
    public Text o_count;
    public Text s_count;
    public Text t_count;
    public Text z_count;

    public Text tetrises;
    public Text triples;
    public Text doubles;
    public Text singles;

    public Text line_count;
    public Text level_count;

    public Text drought;
    public Text trt;

    public Text score_1;
    public Text score_2;
    public Text score_3;
    public Text score_4;
    public Text score_5;

    // Start is called before the first frame update
    void Start()
    {
        i_count = GameObject.Find("i_count").GetComponent<Text>();
        j_count = GameObject.Find("j_count").GetComponent<Text>();
        l_count = GameObject.Find("l_count").GetComponent<Text>();
        o_count = GameObject.Find("o_count").GetComponent<Text>();
        s_count = GameObject.Find("s_count").GetComponent<Text>();
        t_count = GameObject.Find("t_count").GetComponent<Text>();
        z_count = GameObject.Find("z_count").GetComponent<Text>();

        tetrises= GameObject.Find("no_tetris_count").GetComponent<Text>();
        triples = GameObject.Find("triples_count").GetComponent<Text>();
        doubles = GameObject.Find("doubles_count").GetComponent<Text>();
        singles = GameObject.Find("singles_count").GetComponent<Text>();

        line_count = GameObject.Find("line_count").GetComponent<Text>();
        level_count = GameObject.Find("lvl_count").GetComponent<Text>();

        drought = GameObject.Find("drt_count").GetComponent<Text>();
        trt = GameObject.Find("trt_count").GetComponent<Text>();

        score_1 = GameObject.Find("score_1").GetComponent<Text>();
        score_2 = GameObject.Find("score_2").GetComponent<Text>();
        score_3 = GameObject.Find("score_3").GetComponent<Text>();
        score_4 = GameObject.Find("score_4").GetComponent<Text>();
        score_5 = GameObject.Find("score_5").GetComponent<Text>();

        i_count.text = PlayerPrefs.GetString("I");
        j_count.text = PlayerPrefs.GetString("J");
        l_count.text = PlayerPrefs.GetString("L");
        o_count.text = PlayerPrefs.GetString("O");
        s_count.text = PlayerPrefs.GetString("S");
        t_count.text = PlayerPrefs.GetString("T");
        z_count.text = PlayerPrefs.GetString("Z");

        tetrises.text = PlayerPrefs.GetString("Tetrises");
        triples.text = PlayerPrefs.GetString("Triples");
        doubles.text = PlayerPrefs.GetString("Doubles");
        singles.text = PlayerPrefs.GetString("Singles");

        line_count.text = PlayerPrefs.GetString("Line");
        level_count.text = PlayerPrefs.GetString("Level");

        drought.text = PlayerPrefs.GetString("M_Drought");
        trt.text = PlayerPrefs.GetString("TRT");

        score_1.text = PlayerPrefs.GetString("Top_1");
        score_2.text = PlayerPrefs.GetString("Top_2");
        score_3.text = PlayerPrefs.GetString("Top_3");
        score_4.text = PlayerPrefs.GetString("Top_4");
        score_5.text = PlayerPrefs.GetString("Top_5");

        PlayerPrefs.SetString("Singles", "0");
        PlayerPrefs.SetString("Doubles", "0");
        PlayerPrefs.SetString("Triples", "0");
        PlayerPrefs.SetString("Tetrises", "0");

        PlayerPrefs.SetString("I", "0");
        PlayerPrefs.SetString("J", "0");
        PlayerPrefs.SetString("L", "0");
        PlayerPrefs.SetString("O", "0");
        PlayerPrefs.SetString("S", "0");
        PlayerPrefs.SetString("T", "0");
        PlayerPrefs.SetString("Z", "0");

        PlayerPrefs.SetString("Line", "0");
        PlayerPrefs.SetString("Level", "0");

        PlayerPrefs.SetString("M_Drought", "0");
        PlayerPrefs.SetString("TRT", "0%");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
