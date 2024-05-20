using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnPoint : MonoBehaviour
{
    
    public GameObject car;

    void Start()
    {
        int randNum = Random.Range(0,100);
        print("spawn randnum " + randNum);

        if(randNum <= 33){
            Vector3 spawnPosition = new Vector3(647,0,425)
            
        }
        else if(randNum <=66){
            Vector3 spawnPosition = new Vector3(647,0,425)
        }
        else if(randNum <=100){
            Vector3 spawnPosition = new Vector3(647,0,425)
        }

        Instantiate(car, spawnPosition, )
    }

}
