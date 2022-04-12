using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level_Check : MonoBehaviour
{

    public Text line_count;
    public Text level_count;

    public float lvl,curr_lvl;
    public float speed;

    public int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        line_count = GameObject.Find("line_count").GetComponent<Text>();
        level_count = GameObject.Find("level_count").GetComponent<Text>();
        level_count.text = PlayerPrefs.GetString("Start_Level");
    }

    // Update is called once per frame
    void Update()
    {
        lvl = Mathf.Floor(System.Convert.ToInt32(line_count.text) / 20);
        curr_lvl = System.Convert.ToInt32(level_count.text);
        PlayerPrefs.SetString("Line", line_count.text);

        if (i == 0)
        {
            lvl_change();
            i = 1;
        }
        else
        {
            if (lvl > curr_lvl)
            {
                level_count.text = lvl.ToString();
                curr_lvl = lvl;
                lvl_change();
            }
        }

        FindObjectOfType<Piece_Fall>().fall(speed);
    }

    void lvl_change()
    {
        if (curr_lvl <= 2)
        {
            speed = 2f;
        }
        else if (curr_lvl > 2 && curr_lvl <= 5)
        {
            speed = 1f;
        }
        else if (curr_lvl > 5 && curr_lvl <= 8)
        {
            speed = 0.5f;
        }
        else if (curr_lvl > 8 && curr_lvl <= 12)
        {
            speed = 0.3f;
        }
        else if (curr_lvl > 11 && curr_lvl <= 15)
        {
            speed = 0.2f;
        }
        else if (curr_lvl > 15 && curr_lvl <= 18)
        {
            speed = 0.1f;
        }
        else
        {
            speed = 0.05f;
        }
    }
}
