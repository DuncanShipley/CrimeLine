using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movescript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var rb = GetComponent<Rigidbody2D>();
        var spd = 5;
        if(Input.GetKey(KeyCode.LeftShift))
        {
            spd = 12;
        }
        
        Vector3 inp = new Vector3(Input.GetAxis("Horizontal") / spd, Input.GetAxis("Vertical") / spd, 0);
        rb.MovePosition(transform.position + inp);
    }
}
