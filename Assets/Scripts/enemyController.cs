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
    public BoxCollider[] c;
    public AudioClip[] audioClip;
    AudioSource audioc;
    void Awake () {
        if (instance == null) {
            instance = this;

        }
    }
    void Start () {
        anim2 = GetComponent<Animator> ();
        SetAllBoxColliders (false);
        audioc = GetComponent<AudioSource> ();
    }

    public void playAudio (int clip) {
        audioc.clip = audioClip[clip];
        audioc.Play ();
    }
    private void SetAllBoxColliders (bool state) {
        c[0].enabled = state;
        c[1].enabled = state;
    }

    // Update is called once per frame
    void Update () {
        if (anim2.GetCurrentAnimatorStateInfo (0).IsName ("fight_idleCopy")) {
            direction = playerTransform.position - this.transform.position;
            direction.y = 0;
            this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), 1f);
            SetAllBoxColliders (false);
        }
        //Ai for attacks of bear.
        Debug.Log (direction.magnitude);
        //if away from kicking distance, then move forward.
        if (direction.magnitude > 0.45f && GameController.allowMovement == true) {
            anim2.SetTrigger ("walkFwd");
            //when walking, no sound playing.
            audioc.Stop();
            //if walking forward, no colliders enabled
            SetAllBoxColliders (false);
        } else {
            anim2.ResetTrigger ("walkFwd");
        }
        //kicking started
        //GameController.allowMovement == true
        if (direction.magnitude < 0.45f && direction.magnitude > 0.2f && GameController.allowMovement == true) {
            SetAllBoxColliders (true);
            if (!audioc.isPlaying && !anim2.GetCurrentAnimatorStateInfo (0).IsName ("roundhouse_kick 2")) {
                playAudio (0);
                anim2.SetTrigger ("kick");
            }
        } else {
            anim2.ResetTrigger ("kick");
        }

        if (direction.magnitude < 0.2f) {
            SetAllBoxColliders (true);
            if (!audioc.isPlaying && !anim2.GetCurrentAnimatorStateInfo (0).IsName ("cross_punch")) {
                playAudio (1);
                anim2.SetTrigger ("punch");
            }
        } else {
            anim2.ResetTrigger ("punch");
        }

        if (direction.magnitude < 0.15f && direction.magnitude > 0f && GameController.allowMovement == true) {
            anim2.SetTrigger ("walkBack");
             audioc.Stop();
            SetAllBoxColliders (false);
        } else {
            anim2.ResetTrigger ("walkBack");
        }
    }

    public void enemyReact () {
        enemyHealth = enemyHealth - 10;
        //enemyHB.value = enemyHealth;
        if (enemyHealth < 10) {
            enemyKnockout ();
        } else {
            anim2.ResetTrigger ("idle");
            anim2.SetTrigger ("react");
        }
        enemyHB.value = enemyHealth;
    }

    public void enemyKnockout () {
        anim2.SetTrigger ("knockout");
    }
}