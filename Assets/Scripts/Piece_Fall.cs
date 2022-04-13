using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Piece_Fall : MonoBehaviour
{
    private float previousTime;
    public float fallTime;

    public static int height=15;
    public static int width=10;

    public int lines = 0;
    public int level = 0;

    public Text line_count;
    public Text level_count;

    public Text top_count;
    public Text curr_count;

    public double trt;

    public Text tetris_rate;

    public static Transform[,] board=new Transform[width,height+1];

    public float movement = 4f;

    public GameObject piece;

    public int sp=0;

    public GameObject background;
    

    void Start()
    {
        line_count = GameObject.Find("line_count").GetComponent<Text>();
        level_count = GameObject.Find("level_count").GetComponent<Text>();

        top_count = GameObject.Find("top_count").GetComponent<Text>();
        curr_count = GameObject.Find("current_count").GetComponent<Text>();

        tetris_rate = GameObject.Find("trt_count").GetComponent<Text>();

        background = GameObject.Find("background");

    }

    void Update()
    {
        /*if (Input.GetKeyDown("a"))
        {
            transform.position += new Vector3(-1, 0, 0);
            if (!valid_move())
            {
                transform.position -= new Vector3(-1, 0, 0);
            }
        }
        else if (Input.GetKeyDown("d"))
        {
            transform.position += new Vector3(1, 0, 0);
            if (!valid_move())
            {
                transform.position -= new Vector3(1, 0, 0);
            }
        }*/

        if (Time.time-previousTime>(Input.GetKey("s") ? fallTime/5 : fallTime))
        {
            transform.position += new Vector3(0, -1, 0);
            if (!valid_move())
            {
                piece.GetComponent<Piece_Movements>().enabled = false;
                this.enabled = false;
                transform.position -= new Vector3(0, -1, 0);
                add_to_board();
                FindObjectOfType<Piece_Rotations>().disable();
                if(sp==0){
                    FindObjectOfType<Spawn>().spawn();
                }
            }
            previousTime = Time.time;
        }
    }

    public bool valid_move()
    {
        foreach (Transform children in transform)
        {
            int roundX = Mathf.RoundToInt(children.transform.position.x);
            int roundY = Mathf.RoundToInt(children.transform.position.y);

            if (roundX<0||roundX>=width|| roundY < 0 || roundY >= height)
            {
                return false;
            }
            if (board[roundX, roundY]!=null)
            {
                return false;
            }
        }
        return true;
    }

    public void add_to_board()
    {
        int pos_y=0;
        background.GetComponent<Line_Clear>().add_board();
        foreach (Transform children in transform)
        {
            int roundX = Mathf.RoundToInt(children.transform.position.x);
            int roundY = Mathf.RoundToInt(children.transform.position.y);

            board[roundX, roundY] = children;

            if (roundY > pos_y)
            {
                pos_y = roundY;
            }
        }
        if(pos_y>=15){
            background.GetComponent<Game_End>().enabled = true;
            PlayerPrefs.SetString("Level", level_count.text);
            scoring();
            GameObject span = GameObject.Find("Spawn");
            span.SetActive(false);
            sp=1;
            this.GetComponent<Piece_Fall>().enabled = false;
        }
        else{
            check_lines(pos_y+1);
        }
    }

    public void check_lines(int y)
    {

        int no = 0;

        if (y >= 4)
        {
            for (int i = y; i >= y - 4; i--)
            {
                if (has_lines(i))
                {
                    no += 1;
                    delete(i);
                    down(i);
                }
            }
        }
        else if (y == 3)
        {
            for (int i = 2; i >= 0; i--)
            {
                if (has_lines(i))
                {
                    no += 1;
                    delete(i);
                    down(i);
                }
            }
        }
        else if (y == 2)
        {
            for (int i = 1; i >= 0; i--)
            {
                if (has_lines(i))
                {
                    no += 1;
                    delete(i);
                    down(i);
                }
            }
        }
        else if (y == 1)
        {
            if (has_lines(0))
            {
                no += 1;
                delete(0);
                down(0);
            }
        }

        if (no > 0)
        {
            lines += no;
            line_count.text = (System.Convert.ToInt32(line_count.text) + System.Convert.ToInt32(lines)).ToString();

            score(no);
        }
    }

    bool has_lines(int no)
    {
        for (int j = 0; j < width; j++)
        {
            if (board[j, no] == null)
            {
                return false;
            }
        }
        background.GetComponent<Line_Clear>().line_clear(no);
        return true;
    }

    void delete(int no)
    {
        for (int j = 0; j < width; j++)
        {
            Destroy(board[j, no].gameObject);
            board[j, no] = null;
        }
    }

    void down(int y)
    {
        for (int j = y ; j < height; j++)
        {
            for (int k = 0; k < width; k++)
            {
                if (board[k, j] != null)
                {
                    board[k, j - 1] = board[k, j];
                    board[k, j] = null;
                    board[k, j - 1].transform.position -= new Vector3(0, 1, 0);
                }
            }
        }
    }

    public Transform[,] board_transfer()
    {
        return board;
    }

    public void fall(float speed)
    {
        fallTime = speed;
    }

    public void score(int line)
    {
        int base_1 = 200;
        int base_2 = 350;
        int base_3 = 500;
        int base_4 = 3000;

        if (System.Convert.ToInt32(level_count.text) == 0)
        {
            if (line == 1)
            {
                PlayerPrefs.SetString("Singles", (System.Convert.ToInt32(PlayerPrefs.GetString("Singles")) + 1).ToString());
                curr_count.text = (System.Convert.ToInt32(curr_count.text) + 100).ToString();
                background.GetComponent<Line_Clear>().lin();
            }
            else if (line == 2)
            {
                PlayerPrefs.SetString("Doubles", (System.Convert.ToInt32(PlayerPrefs.GetString("Doubles")) + 1).ToString());
                curr_count.text = (System.Convert.ToInt32(curr_count.text) + 225).ToString();
                background.GetComponent<Line_Clear>().lin();
            }
            else if (line == 3)
            {
                PlayerPrefs.SetString("Triples", (System.Convert.ToInt32(PlayerPrefs.GetString("Triples")) + 1).ToString());
                curr_count.text = (System.Convert.ToInt32(curr_count.text) + 400).ToString();
                background.GetComponent<Line_Clear>().lin();
            }
            else if (line == 4)
            {
                PlayerPrefs.SetString("Tetrises", (System.Convert.ToInt32(PlayerPrefs.GetString("Tetrises")) + 1).ToString());
                curr_count.text = (System.Convert.ToInt32(curr_count.text) + 1200).ToString();
                background.GetComponent<Line_Clear>().tet();
            }
        }
        else
        {
            if (line == 1)
            {
                PlayerPrefs.SetString("Singles", (System.Convert.ToInt32(PlayerPrefs.GetString("Singles")) + 1).ToString());
                curr_count.text = (System.Convert.ToInt32(curr_count.text) + (System.Convert.ToInt32(level_count.text) * base_1)).ToString();
                background.GetComponent<Line_Clear>().lin();
            }
            else if (line == 2)
            {
                PlayerPrefs.SetString("Doubles", (System.Convert.ToInt32(PlayerPrefs.GetString("Doubles")) + 1).ToString());
                curr_count.text = (System.Convert.ToInt32(curr_count.text) + (System.Convert.ToInt32(level_count.text) * base_2)).ToString();
                background.GetComponent<Line_Clear>().lin();
            }
            else if (line == 3)
            {
                PlayerPrefs.SetString("Triples", (System.Convert.ToInt32(PlayerPrefs.GetString("Triples")) + 1).ToString());
                curr_count.text = (System.Convert.ToInt32(curr_count.text) + (System.Convert.ToInt32(level_count.text) * base_3)).ToString();
                background.GetComponent<Line_Clear>().lin();
            }
            else if (line == 4)
            {
                PlayerPrefs.SetString("Tetrises", (System.Convert.ToInt32(PlayerPrefs.GetString("Tetrises")) + 1).ToString());
                curr_count.text = (System.Convert.ToInt32(curr_count.text) + (System.Convert.ToInt32(level_count.text) * base_4)).ToString();
                background.GetComponent<Line_Clear>().tet();
            }
        }

        if (System.Convert.ToInt32(curr_count.text) > System.Convert.ToInt32(top_count.text))
        {
            top_count.text = curr_count.text;
        }

        trt = (System.Convert.ToInt32(PlayerPrefs.GetString("Tetrises")) * 4 * 100) / System.Convert.ToInt32(line_count.text);
        PlayerPrefs.SetString("TRT", trt.ToString() + "%");
        tetris_rate.text = trt.ToString() + "%";
    }

    public void scoring()
    {
        if (System.Convert.ToInt32(curr_count.text) > System.Convert.ToInt32(PlayerPrefs.GetString("Top_1")))
        {
            top_count.text = curr_count.text;
            PlayerPrefs.SetString("Top_5", PlayerPrefs.GetString("Top_4"));
            PlayerPrefs.SetString("Top_4", PlayerPrefs.GetString("Top_3"));
            PlayerPrefs.SetString("Top_3", PlayerPrefs.GetString("Top_2"));
            PlayerPrefs.SetString("Top_2", PlayerPrefs.GetString("Top_1"));
            PlayerPrefs.SetString("Top_1", curr_count.text);
        }
        else if (System.Convert.ToInt32(curr_count.text) > System.Convert.ToInt32(PlayerPrefs.GetString("Top_2")))
        {
            PlayerPrefs.SetString("Top_5", PlayerPrefs.GetString("Top_4"));
            PlayerPrefs.SetString("Top_4", PlayerPrefs.GetString("Top_3"));
            PlayerPrefs.SetString("Top_3", PlayerPrefs.GetString("Top_2"));
            PlayerPrefs.SetString("Top_2", curr_count.text);
        }
        else if (System.Convert.ToInt32(curr_count.text) > System.Convert.ToInt32(PlayerPrefs.GetString("Top_3")))
        {
            PlayerPrefs.SetString("Top_5", PlayerPrefs.GetString("Top_4"));
            PlayerPrefs.SetString("Top_4", PlayerPrefs.GetString("Top_3"));
            PlayerPrefs.SetString("Top_3", curr_count.text);
        }
        else if (System.Convert.ToInt32(curr_count.text) > System.Convert.ToInt32(PlayerPrefs.GetString("Top_4")))
        {
            PlayerPrefs.SetString("Top_5", PlayerPrefs.GetString("Top_4"));
            PlayerPrefs.SetString("Top_4", curr_count.text);
        }
        else if (System.Convert.ToInt32(curr_count.text) > System.Convert.ToInt32(PlayerPrefs.GetString("Top_5")))
        {
            PlayerPrefs.SetString("Top_5", curr_count.text);
        }
    }
}
