using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightSizeBK : MonoBehaviour
{
    Color passiveColor;
    private float oldInnerAngle;
    private float oldOuterAngle;
    private float oldOuterRadius;
    UnityEngine.Rendering.Universal.Light2D myLight;
    void Start()
    {
        myLight = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        passiveColor = myLight.color;
    
    }

    void Update()
    {
        if (guardHealthBK.alive && !guardHealthBK.dying)
        {
            myLight.pointLightInnerAngle = WaypointFollowerBK.suspicious * 45 + 75;
            myLight.pointLightOuterAngle = WaypointFollowerBK.suspicious * 45 + 75;
            myLight.pointLightOuterRadius = WaypointFollowerBK.suspicious * 2 + 9;
            myLight.color = Color.Lerp(passiveColor, Color.red, WaypointFollowerBK.suspicious);
            // these change the light's radius, angle, and color based on the guard's suspicion.
            
            oldInnerAngle = myLight.pointLightInnerAngle;
            oldOuterAngle = myLight.pointLightOuterAngle;
            oldOuterRadius = myLight.pointLightOuterRadius;
            //saves the necessary light values for when the guard dies.
        }
        if (guardHealthBK.dying)
        {
            myLight.pointLightInnerAngle = myLight.pointLightInnerAngle - oldInnerAngle * (Time.deltaTime / 2);
            myLight.pointLightOuterAngle = myLight.pointLightOuterAngle - oldOuterAngle * (Time.deltaTime / 2);
            myLight.pointLightOuterRadius = myLight.pointLightOuterRadius - oldOuterRadius * (Time.deltaTime / 2);
            myLight.intensity = myLight.intensity - 1.5f * Time.deltaTime;

        }
    }
}