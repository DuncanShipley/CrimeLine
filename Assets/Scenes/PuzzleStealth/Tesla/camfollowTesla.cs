using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camfollowTesla : MonoBehaviour
{
    private float moveTarget;
    public bool enabled = true;
    private int moveTick;
    bool followingPlayer = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enabled)
        {
            transform.position = GameObject.Find("Player").transform.position + new Vector3(0, 0, -5);
        }
    }

    public bool IsFollowingPlayer()
    {
        return followingPlayer;
    }


}
