using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movescriptT : MonoBehaviour
{
    GameObject ind;
    public GameObject pro;
    Vector3 lastInp;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var rb = GetComponent<Rigidbody2D>();
        var spd = 5;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            spd = 12;
        }

        Vector3 inp = new Vector3(Input.GetAxis("Horizontal") / spd, Input.GetAxis("Vertical") / spd, 0);
        rb.MovePosition(transform.position + inp);

        //Debug.Log(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0);
        Debug.Log(inp + " " + lastInp + " " + Mathf.Abs(Input.GetAxis("Horizontal"))+ " "+ Mathf.Abs(Input.GetAxis("Vertical")));
        
        //if (!(Input.GetAxis("Horizontal")==0 && Input.GetAxis("Vertical")==0))
        if (!(Mathf.Abs(Input.GetAxis("Horizontal"))<.3  && Mathf.Abs(Input.GetAxis("Vertical"))<.3))
            lastInp = inp;

        if (Input.GetKeyDown(KeyCode.E))
        {
            ind = Instantiate(pro, this.gameObject.transform.position, new Quaternion());
            var pRB = pro.GetComponent<Rigidbody2D>();
            pRB.AddRelativeForce(lastInp);
        }
    }
}
