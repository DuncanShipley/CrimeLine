using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightSizeBK : MonoBehaviour
{
    Color passiveColor;
    UnityEngine.Rendering.Universal.Light2D myLight;
    void Start()
    {
        myLight = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        passiveColor = myLight.color;
    
    }

    void Update()
    {
        myLight.pointLightInnerAngle = WaypointFollowerBK.suspicious*45 + 75;
        myLight.pointLightOuterAngle = WaypointFollowerBK.suspicious*45 + 75;
        myLight.pointLightOuterRadius = WaypointFollowerBK.suspicious*2 + 9;
        myLight.color = Color.Lerp(passiveColor, Color.red, WaypointFollowerBK.suspicious);
        // these change the light's radius, angle, and color based on the guard's suspicion.
    }
}