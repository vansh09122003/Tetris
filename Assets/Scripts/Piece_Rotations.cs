using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece_Rotations : MonoBehaviour
{
    public Vector3 rotation_point;

    public static int height = 15;
    public static int width = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.RotateAround(transform.TransformPoint(rotation_point), new Vector3(0, 0, 1), 90);
            var objectName = name.Replace("(Clone)", "");
            if (!valid_move() || objectName == "O Piece")
            {
                transform.RotateAround(transform.TransformPoint(rotation_point), new Vector3(0, 0, 1), -90);
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.RotateAround(transform.TransformPoint(rotation_point), new Vector3(0, 0, 1), -90);
            var objectName = name.Replace("(Clone)", "");
            if (!valid_move() || objectName == "O Piece")
            {
                transform.RotateAround(transform.TransformPoint(rotation_point), new Vector3(0, 0, 1), 90);
            }
        }
    }

    bool valid_move()
    {
        foreach (Transform children in transform)
        {
            int roundX = Mathf.RoundToInt(children.transform.position.x);
            int roundY = Mathf.RoundToInt(children.transform.position.y);

            Transform[,] board = FindObjectOfType<Piece_Fall>().board_transfer();

            if (roundX < 0 || roundX >= width || roundY < 0 || roundY >= height)
            {
                return false;
            }
            if (board[roundX, roundY] != null)
            {
                return false;
            }
        }
        return true;
    }

    public void disable()
    {
        this.enabled = false;
    }
}
