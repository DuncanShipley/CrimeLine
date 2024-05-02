using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guardLightMain : MonoBehaviour
{
    public int id;

    UnityEngine.Rendering.Universal.Light2D myLight;

    // Start is called before the first frame update
    void Start()
    {
        myLight = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        id = gameObject.transform.parent.GetComponent<IDsMain>().GetID();

        if (guardHealthMain.dyingList[id])
        {
            myLight.intensity = myLight.intensity - 0.75f * Time.deltaTime;
        }
    }
}
