using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeLook : MonoBehaviour
{

    public GameObject forward;
    public GameObject backward;
    public int counter;


    //This is Main Camera in the Scene
    public Camera m_MainCamera;
    //This is the second Camera and is assigned in inspector
    public Camera m_CameraTwo;

    void Start()
    {
        //This enables Main Camera
        m_MainCamera.enabled = true;
        //Use this to disable secondary Camera
        m_CameraTwo.enabled = false;
    }

    void Update()
    {
        //Press the L Button to switch cameras
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //Check that the Main Camera is enabled in the Scene, then switch to the other Camera on a key press
            if (m_MainCamera.enabled)
            {
                //Enable the second Camera
                m_CameraTwo.enabled = true;

                //The Main first Camera is disabled
                m_MainCamera.enabled = false;
            }
            //Otherwise, if the Main Camera is not enabled, switch back to the Main Camera on a key press
            else if (!m_MainCamera.enabled)
            {
                //Disable the second camera
                m_CameraTwo.enabled = false;

                //Enable the Main Camera
                m_MainCamera.enabled = true;
            }
        }
    }



    /*    // Start is called before the first frame update
        void Start()
        {
            forward.SetActive(true);
            backward.SetActive(false);
            counter = 0;
            print("5");
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if(true)
                {
                    print("2");
                    lookBack();
                }
            }
        }



        async void lookBack()
        {
            while (true)
            {
                if (counter == 0)
                {
                    print("3");
                    forward.SetActive(false);
                    backward.SetActive(true);
                    counter = 1;
                }
                if (Input.GetKeyUp(KeyCode.LeftShift))
                {
                    print("4");
                    forward.SetActive(true);
                    backward.SetActive(false);
                    counter = 0;
                    break;
                }
            }
        }*/
}
