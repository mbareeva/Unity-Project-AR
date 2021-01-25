using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeeScript : MonoBehaviour
{
    public Transform arCamera;
    public AudioSource source;
    public AudioClip beeSound;
    public HealthBar myHealthBar;
    [SerializeField] private HealthData healthData;

    void Start()
    {
        //bee spawns and finds the AR Camera
        arCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        myHealthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>();
    }

    void Update()
    {
        //make bees fly - moves the objects towards the camera
        transform.LookAt(arCamera, Vector3.up);
        transform.Rotate(0, -100, 0);
        transform.position = Vector3.Lerp(transform.position, arCamera.position, 0.01f);

        float dist = Vector3.Distance(transform.position, arCamera.transform.position);
        if (dist < 1)
        {
                healthData.healthValue -= 5;
                myHealthBar.SetHealth(healthData.healthValue);
                Destroy(gameObject);
        }

    }

}