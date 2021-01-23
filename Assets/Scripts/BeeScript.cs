﻿using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class BeeScript : MonoBehaviour
{
    public Transform arCamera;
    public AudioSource source;
    public HealthBar myHealthBar;
    [SerializeField] private HealthData healthData;

    void Start()
    {
        //bee spawns and finds the AR Camera
        arCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        myHealthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>();
    }

    // Update is called once per frame (60 times pro sec)
    void Update()
    {

        //make bees fly - moves the objects towards the camera
        transform.LookAt(arCamera, Vector3.up);
        transform.Rotate(0, -100, 0);
        transform.position = Vector3.Lerp(transform.position, arCamera.position, 0.01f);

        //source = GetComponent<AudioSource>();

        //collision
        float dist = Vector3.Distance(transform.position, arCamera.transform.position);
        if (dist < 1)
        {
            healthData.healthValue -= 10;
            myHealthBar.SetHealth(healthData.healthValue);
            Destroy(gameObject);
            //source.Play();
            //
            //StartCoroutine(startSound());

            // t.Pause();
            //Scores.scoreValue -= 1;
            //Destroy(gameObject);

        }

    }

    private IEnumerator startSound()
    {

        //yield return new WaitUntil(() => !source.isPlaying);
        source.Play();
        //Destroy(gameObject);
        yield break;


    }

}