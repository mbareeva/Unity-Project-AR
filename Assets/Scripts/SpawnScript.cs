using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public Transform[] spawnPoints; //all the points where we're going to spawn the bees
    public GameObject[] bees; //array which has 3D bee objects

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartSpawning()); //call the spawn process
    }

    IEnumerator StartSpawning() {

        yield return new WaitForSeconds(4);

        for (int i = 0; i < 3; i++)
        {

            //3 args - 1) bees - what to instantiate; 2)the position, 3)default rotation
            Instantiate(bees[i], spawnPoints[i].position, Quaternion.identity);
        }

        //waits for 4 seconds and spawns 3 bees more, and so on..
        StartCoroutine(StartSpawning());
    }

}
