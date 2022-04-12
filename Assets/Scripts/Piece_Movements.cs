using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece_Movements : MonoBehaviour
{
    private float previousTime;
    public int next_movement = 0;

    void FixedUpdate()
    {

        if (Input.GetKey("a"))
        {
            das_left();
            next_movement += 1;
            if (Input.GetKeyUp("a"))
            {
                next_movement = 0;
            }
        }
        else if (Input.GetKey("d"))
        {
            das_right();
            next_movement += 1;
            if (Input.GetKeyUp("d"))
            {
                next_movement = 0;
            }
        }

        /*if (Input.GetKeyDown("a"))
        {
            left();
        }
        else if (Input.GetKeyDown("d"))
        {
            right();
        }*/
    }

    public void das_left()
    {
        if (next_movement == 5)
        {
            left();
            next_movement = 0;
        }
    }

    public void das_right()
    {
        if (next_movement == 5)
        {
            right();
            next_movement = 0;
        }
    }

    public void left()
    {
        transform.position += new Vector3(-1, 0, 0);
        if (!FindObjectOfType<Piece_Fall>().valid_move())
        {
            transform.position -= new Vector3(-1, 0, 0);
        }
    }

    public void right()
    {
        transform.position += new Vector3(1, 0, 0);
        if (!FindObjectOfType<Piece_Fall>().valid_move())
        {
            transform.position -= new Vector3(1, 0, 0);
        }
    }
}
