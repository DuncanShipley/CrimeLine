using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardVariablesTesla : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public float GetChaseSpeed()
    {
        if (name == "Elite Guard") { return 5f; }
        else { return 4.5f; }
    }
    public float GetBaseSpeed()
    {
        return 3f;
    }
    public int GetHealth()
    {
        if (name == "Elite Guard") { return 4; }
        else { return 2; }
    }
    public float GetShootWait()
    {
        if (name == "Elite Guard") { return 0.25f; }
        else { return 0.5f; }
    }
}
