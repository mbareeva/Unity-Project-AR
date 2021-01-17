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
    private Vector3 enemyPosition;
    void Awake () {
        if (instance == null) {
            instance = this;

        }
    }
    void Start () {
        anim2 = GetComponent<Animator> ();
        SetAllBoxColliders (false);
        audioc = GetComponent<AudioSource> ();
        enemyPosition = transform.position;
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
        //Debug.Log (direction.magnitude);
        //if away from kicking distance, then move forward.
        if (direction.magnitude > 0.25f && GameController.allowMovement == true) {
            anim2.SetTrigger ("walkFwd");
            //when walking, no sound playing.
            audioc.Stop();
            //if walking forward, no colliders enabled
            SetAllBoxColliders (false);
        } else {
            anim2.ResetTrigger ("walkFwd");
        }
        //kicking started
        if (direction.magnitude > 0.1f && direction.magnitude < 0.2f && GameController.allowMovement == true) {
            SetAllBoxColliders (true);
            if (!audioc.isPlaying && !anim2.GetCurrentAnimatorStateInfo (0).IsName ("roundhouse_kick 2")) {
                playAudio (0);
                anim2.SetTrigger ("kick");
                SetAllBoxColliders (true);
            }
        } else {
            anim2.ResetTrigger ("kick");
        }

        if (direction.magnitude < 0.15f) {
            SetAllBoxColliders (true);
            if (!audioc.isPlaying && !anim2.GetCurrentAnimatorStateInfo (0).IsName ("cross_punch")) {
                playAudio (1);
                anim2.SetTrigger ("punch");
                //if he is punching, enable hos colliders
                SetAllBoxColliders (true);
            }
        } else {
            anim2.ResetTrigger ("punch");
        }

        if (direction.magnitude < 0.13f && direction.magnitude > 0f && GameController.allowMovement == true) {
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
            playAudio (2);
        } else {
            anim2.ResetTrigger ("idle");
            anim2.SetTrigger ("react");
            playAudio (3);
        }
        enemyHB.value = enemyHealth;
    }
/*
* Player knocks the enemy out. When enemy is knockedout, the palyer
* stops moving. The round is reset to the next. The health of both players is reset to 100.
*/
    public void enemyKnockout () {
        GameController.allowMovement = false;
        //reset for the next round the health
        enemyHealth = 100;
        anim2.SetTrigger ("knockout");
        //if bear is knocked out, score to the player.
        GameController.instance.scorePlayer();
        GameController.instance.onScreenPoints();
        GameController.instance.rounds();
        //if the end of 2nd round & she has won
        if(GameController.playerScore == 2) {
            //resetting on screen scoring points.
            GameController.instance.doReset();
        } else {
            StartCoroutine(resetCharacters());
        }
    }

    IEnumerator resetCharacters() {
        yield return new WaitForSeconds(5);
        enemyHB.value = 100;
        //reset position
        Transform t = this.GetComponent<Transform> ();
        anim2.SetTrigger("idle");
        anim2.ResetTrigger("knockout");
        t.position = enemyPosition;
        t.position = new Vector3(0.4f, 0.1f, t.position.z);
        GameController.allowMovement = true;
    }
}