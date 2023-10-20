using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movescriptT : MonoBehaviour
{
    GameObject copy;
    public GameObject projectile;
    Vector3 lastInput;
    float h = 0f;
    float v = 0f;
    float throwPause = 0;
    int thrown = 0;
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

        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        if ((Mathf.Abs(h) > 0) || (Mathf.Abs(v) > 0))
        {
            if (Mathf.Abs(h) > 0)
                lastInput.x = (h / Mathf.Abs(h)) * 100;
            else if (Mathf.Abs(v) - Mathf.Abs(h) > .1)
                lastInput.x = 0;

            if (Mathf.Abs(v) > 0)
                lastInput.y = (v / Mathf.Abs(v)) * 100;
            else if (Mathf.Abs(h) - Mathf.Abs(v) > .1)
                lastInput.y = 0;
        }
        throwPause += Time.deltaTime;

        //creates a projectile moving in the same direction as last player movement
        if (Input.GetKeyDown(KeyCode.E) && projectileT.availible > 0 && throwPause>=1)
        {
            thrown++;
            Debug.Log(thrown);
            throwPause = 0;
            //projectileT.availible--;
            copy = Instantiate(projectile, gameObject.transform.position, new Quaternion());
            var projectileRB = copy.GetComponent<Rigidbody2D>();
            projectileRB.AddRelativeForce(lastInput);
        }
    }
}