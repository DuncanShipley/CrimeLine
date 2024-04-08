using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radio : MonoBehaviour
{
    public GameObject guard;
    private bool placed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Guard")
        {
            gameObject.SetActive(false);
        }
    }

    public void activate(Vector3 pos)
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!placed && Input.GetKeyDown(KeyCode.X)) 
        {
            gameObject.SetActive(true);
            transform.position = GameObject.Find("Player").transform.position;
            guardChaseBK.putWaypoint(transform.position, 0);
            guardChaseBK.currentPointIndex[0] = 0;
            placed = true;
        }
    }
}
