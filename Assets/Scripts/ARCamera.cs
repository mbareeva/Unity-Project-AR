﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ARCamera : MonoBehaviour
{

	public int maxHealth = 100;
	public static int currentHealth;
	public HealthBar healthBar;

	// Start is called before the first frame update
	void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))    
		{
			healthBar.SetMaxHealth(maxHealth);
			currentHealth -= 20;
		}
	}

	//void TakeDamage(int damage)
	//{
	//	currentHealth -= damage;

	//	healthBar.SetHealth(currentHealth);
	//}
}