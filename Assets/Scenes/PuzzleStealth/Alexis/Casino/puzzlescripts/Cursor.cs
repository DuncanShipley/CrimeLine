using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorAlexis : MonoBehaviour
{
    // PRIVATE VARS
    public int cx = 0; // x pos within puzzle grid
    public int cy = 0; // y pos within puzzle grid
    public int gx = 0; // Puzzle grid width
    public int gy = 0; // Puzzle grid height
    public int gw = 0; // Width of each puzzle grid tile
    public int gh = 0; // Height of each puzzle grid tile

    public void listen()
    {
        int x = 0;
        int y = 0;

        if (Input.GetKeyDown(KeyCode.RightArrow) && cx < gx)
        {
            x++;
            cx++;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && cx > 0)
        {
            x--;
            cx--;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && cy < gy)
        {
            y++;
            cy++;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && cy > 0)
        {
            y--;
            cy--;
        }

        transform.position = new Vector3(transform.position.x + (x * gw), transform.position.y + (y * gw), transform.position.z);
    }

    public void setup(int cx, int cy, int gx, int gy, int gw, int gh)
    {
        // Make this object's sprite visable
        gameObject.GetComponent<Image>().enabled = true;

        // Pass params to private vars
        this.cx = cx;
        this.cy = cy;
        this.gx = gx;
        this.gy = gy;
        this.gw = gw;
        this.gh = gh;
    }

    public int gridPos()
    {
        return (cy * gy) + gx;
    }

}
