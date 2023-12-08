using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarFlipUpright : MonoBehaviour
{
    [SerializeField]
    float eulerAngX;
    [SerializeField]
    float eulerAngZ;
    [SerializeField] private GameObject Car;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        eulerAngX = transform.localEulerAngles.x;
        eulerAngZ = transform.localEulerAngles.z;
        if (Input.GetKeyDown("r"))
        {

            if ((eulerAngX >= 135f && eulerAngX <= 225f) || (eulerAngZ <= -135f && eulerAngZ >= -225f) || (eulerAngX <= -135f && eulerAngX >= -225f) || (eulerAngZ >= 135f && eulerAngZ <= 225f))
            {
                this.gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
                Car.transform.Rotate(0, 0, 180, Space.Self);
                print("1");
                print(eulerAngX);
                print(eulerAngZ);
                EventManager.OnTimerUpdate(-5);
            }
            else if ((eulerAngZ <= -45f && eulerAngZ >= -135f) || (eulerAngZ >= 45f && eulerAngZ <= 135f))
            {
                this.gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
                Car.transform.Rotate(0, 0, -90, Space.Self);
                print("2");
                EventManager.OnTimerUpdate(-5);
            }
            else if ((eulerAngZ >= 45f && eulerAngZ <= 135f) || (eulerAngZ <= -45f && eulerAngZ >= -135f))
            {
                this.gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
                Car.transform.Rotate(0, 0, -90, Space.Self);
                print("3");
                EventManager.OnTimerUpdate(-5);
            }
            else if ((eulerAngZ >= 225f && eulerAngZ <= 315f) || (eulerAngZ <= -225f && eulerAngZ >= -315f))
            {
                this.gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
                Car.transform.Rotate(0, 0, 90, Space.Self);
                print("4");
                EventManager.OnTimerUpdate(-5);
            }
        }

    }
}


