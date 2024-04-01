using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightSizeBK : MonoBehaviour
{
    Color passiveColor;
    UnityEngine.Rendering.Universal.Light2D myLight;
    public int id;
    // Start is called before the first frame update
    void Start()
    {
        myLight = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        passiveColor = myLight.color;
    }

    // Update is called once per frame
    void Update()
    {
        id = gameObject.transform.parent.parent.GetComponent<IDs>().GetID();

        myLight.pointLightInnerAngle = WaypointFollowerBK.sus[id] * 45 + 75;
        myLight.pointLightOuterAngle = WaypointFollowerBK.sus[id] * 45 + 75;
        myLight.pointLightOuterRadius = WaypointFollowerBK.sus[id] * 2 + 9;
        myLight.color = Color.Lerp(passiveColor, Color.red, WaypointFollowerBK.sus[id]);
        // these change the light's radius, angle, and color based on the guard's suspicion.
    }
}
