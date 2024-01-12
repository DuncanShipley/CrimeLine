using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guardLightBK : MonoBehaviour
{
    UnityEngine.Rendering.Universal.Light2D myLight;

    // Start is called before the first frame update
    void Start()
    {
        myLight = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (guardHealthBK.dying)
        {
            myLight.intensity = myLight.intensity - 0.75f * Time.deltaTime;
        }
    }
}
