using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fighterController : MonoBehaviour {
    // Start is called before the first frame update
    public Transform enemyTarget;
    static Animator anim;
    //buttons on the display.
    public static bool mvBack = false;
    public static bool mvFwd = false;
    //make the script available for other sections/scripts.
    public static fighterController instance;
    public static bool isAttacking = false;
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
        //make the moving back & fwd functional after kick or punch.
    if(anim.GetCurrentAnimatorStateInfo(0).IsName("fight_idle")) {
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
        anim.ResetTrigger("idle");
        anim.SetTrigger("punch");
    }
    public void kick () {
        isAttacking = true;
        anim.ResetTrigger("idle");
        anim.SetTrigger("kick");
    }
    public void react () {
        isAttacking = true;
        anim.ResetTrigger("idle");
        anim.SetTrigger("react");
    }

}