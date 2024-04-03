using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject Player;
    public GameObject Waypoint1;
    public static List<Vector3> startingPosition = new List<Vector3>();
    public static List<Vector3> position = new List<Vector3>();

    public float leftDetectEdge;
    public float rightDetectEdge;
    public static float detectRadius = 90;
    private bool seesPlayer;

    int movingLeft;
    bool movingDown;
    RaycastHit2D seeingRay;

    public int id;

    float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        Waypoint1 = GameObject.Find("Waypoint 1");
        startingPosition.Add(Vector3.zero);
        position.Add(Vector3.zero);

    }
    // Update is called once per frame
    void Update()
    {
        leftDetectEdge = transform.eulerAngles.z - 270 - detectRadius / 2;
        rightDetectEdge = transform.eulerAngles.z - 90 + detectRadius / 2;

        seesPlayer = CheckFor(Player);

        if (leftDetectEdge < -detectRadius / 2)
        {
            leftDetectEdge += 360;
        }
        if (rightDetectEdge < detectRadius / 2)
        {
            rightDetectEdge += 360;
        } // establish the radii within which the guard can detect the player
        if (Vector2.Distance(transform.position, Player.transform.position) < detectRadius / 7 && seesPlayer) // if the player is within the guard's light
        {
            Debug.Log("i see u");
        }
    }

    public bool CheckFor(GameObject cf)
    {
        for (float i = 0; i < 50; i++)
        {
            if (!movingDown && movingLeft != 180)
            {
                seeingRay = Physics2D.Raycast(transform.position, new Vector2((float)-Math.Sin((((50 - i) * (leftDetectEdge + 360) * Math.PI / 180) + i * transform.rotation.eulerAngles.z * Math.PI / 180) / 50), (float)Math.Cos((((50 - i) * (leftDetectEdge + 360) * Math.PI / 180) + i * transform.rotation.eulerAngles.z * Math.PI / 180) / 50)), 5, Physics.DefaultRaycastLayers, -Mathf.Infinity, Mathf.Infinity);
                Debug.DrawRay(transform.position, new Vector2((float)-Math.Sin((((50 - i) * (leftDetectEdge + 360) * Math.PI / 180) + i * transform.rotation.eulerAngles.z * Math.PI / 180) / 50), (float)Math.Cos((((50 - i) * (leftDetectEdge + 360) * Math.PI / 180) + i * transform.rotation.eulerAngles.z * Math.PI / 180) / 50)));
            }
            else
            {
                seeingRay = Physics2D.Raycast(transform.position, new Vector2((float)-Math.Sin((((50 - i) * leftDetectEdge * Math.PI / 180) + i * transform.rotation.eulerAngles.z * Math.PI / 180) / 50), (float)Math.Cos((((50 - i) * leftDetectEdge * Math.PI / 180) + i * transform.rotation.eulerAngles.z * Math.PI / 180) / 50)), 5, Physics.DefaultRaycastLayers, -Mathf.Infinity, Mathf.Infinity);
                Debug.DrawRay(transform.position, new Vector2((float)-Math.Sin((((50 - i) * leftDetectEdge * Math.PI / 180) + i * transform.rotation.eulerAngles.z * Math.PI / 180) / 50), (float)Math.Cos((((50 - i) * leftDetectEdge * Math.PI / 180) + i * transform.rotation.eulerAngles.z * Math.PI / 180) / 50)));
            }
            if (seeingRay.collider != null)
            {
                if (seeingRay.collider.gameObject == cf)
                {
                    return true;
                }
            }
            if (!movingDown && movingLeft == 180)
            {
                seeingRay = Physics2D.Raycast(transform.position, new Vector2((float)-Math.Sin(((i * (rightDetectEdge - 360) * Math.PI / 180) + (50 - i) * transform.rotation.eulerAngles.z * Math.PI / 180) / 50), (float)Math.Cos(((i * (rightDetectEdge - 360) * Math.PI / 180) + (50 - i) * transform.rotation.eulerAngles.z * Math.PI / 180) / 50)), 5, Physics.DefaultRaycastLayers, -Mathf.Infinity, Mathf.Infinity);
                Debug.DrawRay(transform.position, new Vector2((float)-Math.Sin(((i * (rightDetectEdge - 360) * Math.PI / 180) + (50 - i) * transform.rotation.eulerAngles.z * Math.PI / 180) / 50), (float)Math.Cos(((i * (rightDetectEdge - 360) * Math.PI / 180) + (50 - i) * transform.rotation.eulerAngles.z * Math.PI / 180) / 50)));
            }
            else
            {
                seeingRay = Physics2D.Raycast(transform.position, new Vector2((float)-Math.Sin(((i * rightDetectEdge * Math.PI / 180) + (50 - i) * transform.rotation.eulerAngles.z * Math.PI / 180) / 50), (float)Math.Cos(((i * rightDetectEdge * Math.PI / 180) + (50 - i) * transform.rotation.eulerAngles.z * Math.PI / 180) / 50)), 5, Physics.DefaultRaycastLayers, -Mathf.Infinity, Mathf.Infinity);
                Debug.DrawRay(transform.position, new Vector2((float)-Math.Sin(((i * rightDetectEdge * Math.PI / 180) + (50 - i) * transform.rotation.eulerAngles.z * Math.PI / 180) / 50), (float)Math.Cos(((i * rightDetectEdge * Math.PI / 180) + (50 - i) * transform.rotation.eulerAngles.z * Math.PI / 180) / 50)));

            }
            if (seeingRay.collider != null)
            {
                if (seeingRay.collider.gameObject == cf)
                {
                    return true;
                }
            }
        }
        return false;
    }

}
