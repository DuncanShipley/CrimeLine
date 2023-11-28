using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightSizeA : MonoBehaviour
{
    Color passiveColor;
    UnityEngine.Rendering.Universal.Light2D myLight;
    // Start is called before the first frame update
    void Start()
    {
        myLight = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        passiveColor = myLight.color;
    }

    // Update is called once per frame
    void Update()
    {
        myLight.pointLightInnerAngle = WaypointFollower.suspicious * 45 + 75;
        myLight.pointLightOuterAngle = WaypointFollower.suspicious * 45 + 75;
        myLight.pointLightOuterRadius = WaypointFollower.suspicious * 2 + 9;
        myLight.color = Color.Lerp(passiveColor, Color.red, WaypointFollower.suspicious);
        // these change the light's radius, angle, and color based on the guard's suspicion.
    }
}
