using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnScript : MonoBehaviour
{
    public Transform[] spawnPoints; 
    public GameObject[] bees;
    public HealthBar myHealthBar;
    [SerializeField] private HealthData healthData;

    void Start()
    {
        healthData.healthValue = 100;
        myHealthBar.SetHealth(healthData.healthValue);
        StartCoroutine(StartSpawning());
        
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
            Instantiate(bees[i], pos, Quaternion.identity);
        }

        StartCoroutine(StartSpawning());
    }

}
