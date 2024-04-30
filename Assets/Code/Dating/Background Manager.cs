using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
     InkExternalFunctions IKF;
       void Awake()
    {
         IKF = GameObject.FindGameObjectWithTag("Ink External Functions").GetComponent<InkExternalFunctions>();
    }
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
