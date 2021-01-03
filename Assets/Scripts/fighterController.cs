using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class fighterController : MonoBehaviour {
    // Start is called before the first frame update
    public Transform enemyTarget;
    static Animator anim;
    public Slider playerHB;
    //buttons on the display.
    public static bool mvBack = false;
    public static bool mvFwd = false;
    //make the script available for other sections/scripts.
    public static fighterController instance;
    public static bool isAttacking = false;

    public int health  = 100;
    private Vector3 direction; //between the main player and enemy.
    void Awake () {
        if (instance == null) {
            instance = this;
        }
    }
    void Start () {
        anim = GetComponent<Animator> ();
    }

    // Update is called once per frame
    void Update () {
        //define the vector between the player and enemy that is always updated for implementation of keeping the eye contact
        // between the characters.
        //when player does not move forward or back (in idle state), then rotate.
        if (anim.GetCurrentAnimatorStateInfo (0).IsName ("fight_idle")) {
            direction = enemyTarget.position - this.transform.position;
            direction.y = 0; //to escape crazy behaviour when player is too close to enemy.
            //rotate the current player according to changing direction with a speed 1f.
            this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), 0.3f);
        }
        //make the moving back & fwd functional after kick or punch.
        if (anim.GetCurrentAnimatorStateInfo (0).IsName ("fight_idle")) {
            isAttacking = false;
        }

        if (isAttacking == false) {
            if (mvBack == true) {
                anim.SetTrigger ("wkBack");
                anim.ResetTrigger ("idle");
            } else {
                anim.SetTrigger ("idle");
                anim.ResetTrigger ("wkBack");
            }

            if (mvFwd == true) {
                anim.SetTrigger ("wkFwd");
                anim.ResetTrigger ("idle");
            } else if (mvBack == false) {
                anim.SetTrigger ("idle");
                anim.ResetTrigger ("wkFwd");
            }
        }

    }

    public void punch () {
        isAttacking = true;
        anim.ResetTrigger ("idle");
        anim.SetTrigger ("punch");
    }
    public void kick () {
        isAttacking = true;
        anim.ResetTrigger ("idle");
        anim.SetTrigger ("kick");
    }
    public void react () {
        isAttacking = true;
        anim.ResetTrigger ("idle");
        anim.SetTrigger ("react");
        health = health - 10;
        playerHB.value = health;
    }

}