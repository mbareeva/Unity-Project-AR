using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyController : MonoBehaviour {
    public Transform playerTransform;
    private Vector3 direction;
    static Animator anim2;
   public int enemyHealth = 100;
   public static enemyController instance;
   public Slider enemyHB;
   void Awake() {
       if(instance == null) {
           instance = this;
            
       }
   }
    void Start () {
        anim2 = GetComponent<Animator> ();
    }

    // Update is called once per frame
    void Update () {
       // if (anim2.GetCurrentAnimatorStateInfo (0).IsName ("fight_idle")) {
            direction = playerTransform.position - this.transform.position;
            direction.y = 0;
            this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), 1f);
       // }
    }

    public void enemyReact() {
        enemyHealth = enemyHealth - 10;
        enemyHB.value = enemyHealth;
        if(enemyHealth < 10){
            enemyKnockout();
        } else {
            anim2.ResetTrigger("idle");
            anim2.SetTrigger("react");
        }
        
    }
    
    public void enemyKnockout() {
        anim2.SetTrigger("knockout");
    }
}