//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;


//public class ARCamera : MonoBehaviour
//{
//	public Transform arCamera;
//	public int maxHealth = 100;
//	public int currentHealth;
//	public HealthBar myHealthBar;
//	public Transform enemyBee;
//	//public int maxHealth = 100;
//	//public int currentHealth;
//	// Start is called before the first frame update
//	void Start()
//    {
//		myHealthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>();
//		myHealthBar.currentHealth = myHealthBar.maxHealth;
//		myHealthBar.SetMaxHealth(myHealthBar.maxHealth);
//	}

//    // Update is called once per frame
//    void Update()
//	{
//		enemyBee = GameObject.FindGameObjectWithTag("EnemyBee").GetComponent<Transform>();

//		float dist = Vector3.Distance(arCamera.transform.position, enemyBee.transform.position);
//		if (dist < 1)
//		{
//			//healthBar.SetMaxHealth(maxHealth);
//			myHealthBar.currentHealth -= 20;
//			myHealthBar.SetHealth(myHealthBar.currentHealth);

//			//source.Play();
//			//
//			//StartCoroutine(startSound());

//			// t.Pause();
//			//Scores.scoreValue -= 1;
//			//Destroy(gameObject);

//		}
//	}

//	//void TakeDamage(int damage)
//	//{
//	//	currentHealth -= damage;

//	//	healthBar.SetHealth(currentHealth);
//	//}
//}