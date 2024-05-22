using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnPoint : MonoBehaviour
{
    
    public GameObject car;

    void Start()
    {
        print("started");

        int randNum = Random.Range(0,100);
        print("spawn randnum: " + randNum);
        Vector3 spawnPosition = new Vector3(0,0,0);
        int num = 0;

        while(num < 1){
            if(randNum >= 66){
                spawnPosition = new Vector3(647,0,425);
                print("a");
            }
            else if(randNum >= 33){
                spawnPosition = new Vector3(600,0,425);
                print("b");
            }
            else{
                spawnPosition = new Vector3(700,0,425);
                print("c");
            }
            print("exited ifs");

            Instantiate(car, spawnPosition, Quaternion.identity);
            print("car made");

            num = 1;
            print("counter: " + num);
            break;
        }
    }

}
