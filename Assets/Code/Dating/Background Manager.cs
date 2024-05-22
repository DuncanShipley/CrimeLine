using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour
{
     InkExternalFunctions IKF;
     Image iRend;
     BackgroundManager backgrounds;
     public string BackgroundOrder= "Inside bank, Outside bank";
     [SerializeField] public Sprite[] Backgrounds;

       void Awake()
    {
         IKF = GameObject.FindGameObjectWithTag("Ink External Functions").GetComponent<InkExternalFunctions>();
         backgrounds = GameObject.FindGameObjectWithTag("Background").GetComponent<BackgroundManager>();
         iRend = GetComponent<Image>();
         backgrounds.changeBackground("OutsideBank");
    }
     public void changeBackground(string ActiveBackground)
     {
               Debug.Log("Changing background to " + ActiveBackground);
               StartCoroutine(ActiveBackground); 
     }
     IEnumerator InsideBank()
     {
          iRend.sprite = Backgrounds[0];
          yield return null;
     }
     IEnumerator OutsideBank()
     {
          iRend.sprite = Backgrounds[1];
          yield return null;
     }
     IEnumerator UnderBridge()
     {
          iRend.sprite = Backgrounds[2];
          yield return null;
     }
     IEnumerator CoffeeShop()
     {
          iRend.sprite = Backgrounds[3];
          yield return null;
     }
     IEnumerator Rooftop()
     {
          iRend.sprite = Backgrounds[4];
          yield return null;
     }
}
