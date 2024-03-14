using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textController : MonoBehaviour
{
    public bool enabled;
    private static List<string> textQueue = new List<string>();


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        void Update()
        {
            makeMovements();
        }

        void makeMovements()
        {
            if (enabled)
            {
                if (transform.position.y < 70)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + 20f, transform.position.z);
                }
            }
            else
            {
                if (transform.position.y > -130)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y - 20f, transform.position.z);
                }
            }
        }
    }

    
}
