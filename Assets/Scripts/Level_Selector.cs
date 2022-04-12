using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Selector : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown("s"))
        {
            transform.position += new Vector3(0, -2, 0);
            if (!valid_move())
            {
                transform.position -= new Vector3(0, -2, 0);
            }
        }
        else if (Input.GetKeyDown("w"))
        {
            transform.position += new Vector3(0, 2, 0);
            if (!valid_move())
            {
                transform.position -= new Vector3(0, 2, 0);
            }
        }
        else if (Input.GetKeyDown("d"))
        {
            transform.position += new Vector3(2, 0, 0);
            if (!valid_move())
            {
                transform.position -= new Vector3(2, 0, 0);
            }
        }
        else if (Input.GetKeyDown("a"))
        {
            transform.position += new Vector3(-2, 0, 0);
            if (!valid_move())
            {
                transform.position -= new Vector3(-2, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            on_enter();
        }
    }

    bool valid_move()
    {
        int roundX = Mathf.RoundToInt(transform.position.x);
        int roundY = Mathf.RoundToInt(transform.position.y);

        if (roundX < 8 || roundX > 17 || roundY < 8 || roundY > 15)
        {
            return false;
        }

        return true;
    }

    public void on_enter()
    {
        Vector3 position = transform.position;

        if (position.x > 16 && position.y < 9)
        {
            PlayerPrefs.SetString("Start_Level", "19");
        }
        else if (position.x > 16 && position.y < 11)
        {
            PlayerPrefs.SetString("Start_Level", "14");
        }
        else if (position.x > 16 && position.y < 13)
        {
            PlayerPrefs.SetString("Start_Level", "9");
        }
        else if (position.x > 16 && position.y < 15)
        {
            PlayerPrefs.SetString("Start_Level", "4");
        }

        else if (position.x > 14 && position.y < 9)
        {
            PlayerPrefs.SetString("Start_Level", "18");
        }
        else if (position.x > 14 && position.y < 11)
        {
            PlayerPrefs.SetString("Start_Level", "13");
        }
        else if (position.x > 14 && position.y < 13)
        {
            PlayerPrefs.SetString("Start_Level", "8");
        }
        else if (position.x > 14 && position.y < 15)
        {
            PlayerPrefs.SetString("Start_Level", "3");
        }

        else if (position.x > 12 && position.y < 9)
        {
            PlayerPrefs.SetString("Start_Level", "17");
        }
        else if (position.x > 12 && position.y < 11)
        {
            PlayerPrefs.SetString("Start_Level", "12");
        }
        else if (position.x > 12 && position.y < 13)
        {
            PlayerPrefs.SetString("Start_Level", "7");
        }
        else if (position.x > 12 && position.y < 15)
        {
            PlayerPrefs.SetString("Start_Level", "2");
        }

        else if (position.x > 10 && position.y < 9)
        {
            PlayerPrefs.SetString("Start_Level", "16");
        }
        else if (position.x > 10 && position.y < 11)
        {
            PlayerPrefs.SetString("Start_Level", "11");
        }
        else if (position.x > 10 && position.y < 13)
        {
            PlayerPrefs.SetString("Start_Level", "6");
        }
        else if (position.x > 10 && position.y < 15)
        {
            PlayerPrefs.SetString("Start_Level", "1");
        }

        else if(position.x < 9 && position.y > 14)
        {
            PlayerPrefs.SetString("Start_Level", "0");
        }
        else if (position.x < 9 && position.y > 12)
        {
            PlayerPrefs.SetString("Start_Level", "5");
        }
        else if (position.x < 9 && position.y > 10)
        {
            PlayerPrefs.SetString("Start_Level", "10");
        }
        else if (position.x < 9 && position.y > 8)
        {
            PlayerPrefs.SetString("Start_Level", "15");
        }

        SceneManager.LoadScene("Main");
    }
}
