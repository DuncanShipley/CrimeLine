using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
public class GameState : MonoBehaviour
{ 

    public struct Enemy
    {
        public string name;
        public bool isAlive;
        public int room;
    }
    static double heistTime;
    static string curMap;
    static ArrayList enemyList;
    
    

    public GameState(bool yeah)
    { 
        
            
    }

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void saveGamestate()
    {
       
    }

    

    
}
