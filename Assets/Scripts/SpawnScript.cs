using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnScript : MonoBehaviour
{
    public Transform[] spawnPoints; //all the points where we're going to spawn the bees
    public GameObject[] bees; //array which has 3D bee objects
    public HealthBar myHealthBar;
    [SerializeField] private HealthData healthData;

    // Start is called before the first frame update
    void Start()
    {
        healthData.healthValue = 100;
        myHealthBar.SetHealth(healthData.healthValue);
        StartCoroutine(StartSpawning()); //call the spawn process
        
    }

    IEnumerator StartSpawning() {

        if (healthData.healthValue == 0)
        {
            SceneManager.LoadScene("Uebergang-nach-Kampf");
        }

        yield return new WaitForSeconds(2);

        for (int i = 0; i < 1; i++)
        {
            if (healthData.healthValue == 0)
            {
                SceneManager.LoadScene("Uebergang-nach-Kampf");
            }
            Vector3 pos = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));
            //3 args - 1) bees - what to instantiate; 2)the position, 3)default rotation
            Instantiate(bees[i], pos, Quaternion.identity);
        }

        //waits for 2 seconds and spawns a bee, and so on..
        StartCoroutine(StartSpawning());
    }

}
