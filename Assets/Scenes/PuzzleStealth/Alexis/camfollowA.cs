using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camfollowA : MonoBehaviour
{
    private float moveTarget;
    public bool enabled = true;
    private int moveTick;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (moveTick != 0)
        {
            transform.position = transform.position + new Vector3(0, moveTarget / 10, 0);
            moveTick--;
        }
        else if (enabled)
        {
            transform.position = GameObject.Find("Player").transform.position + new Vector3(0, 1, -5);
        }
    }

    public void enable()
    {
        moveTarget = 2;
        moveTick = 10;
        enabled = true;
    }

    public void disable()
    {
        moveTarget = -2;
        moveTick = 10;
        enabled = false;
    }

}
