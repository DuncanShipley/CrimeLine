using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movescriptA : MonoBehaviour
{
    GameObject copy;
    public GameObject projectile;
    Vector3 lastInput;
    // Start is called before the first frame update
    void Start()
    {
        // SetTilemapShadows.UpdateShadows();
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
       
        if (!(Mathf.Abs(Input.GetAxis("Horizontal"))<.3  && Mathf.Abs(Input.GetAxis("Vertical"))<.3))
            lastInput = inp*10000f;
     

        //creates a projectile moving in the same direction as last player movement
        if (Input.GetKeyDown(KeyCode.E) && projectileT.availible > 0)
        {
            projectileT.availible--;
            copy = Instantiate(projectile, gameObject.transform.position, new Quaternion());
            var pRB = copy.GetComponent<Rigidbody2D>();
            pRB.AddRelativeForce(lastInput);
        }
    }
}
