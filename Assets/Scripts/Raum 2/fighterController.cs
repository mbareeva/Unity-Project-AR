using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class fighterController : MonoBehaviour {
    public Transform enemyTarget;
    static Animator anim;
    public Slider playerHB;
    //buttons on the display.
    public static bool mvBack = false;
    public static bool mvFwd = false;
    //make the script available for other sections/scripts.
    public static fighterController instance;
    public static bool isAttacking = false;
    public BoxCollider[] c;

    public AudioClip[] audioClip;
    AudioSource audioc;

    public int health = 100;
    private Vector3 direction; //between the main player and enemy.
    private Vector3 playerPosition;

    public GameObject canvas;
    void Awake () {
        if (instance == null) {
            instance = this;
        }
    }
    void Start () {
        anim = GetComponent<Animator> ();
        SetAllBoxColliders (false);
        audioc = GetComponent<AudioSource> ();
        playerPosition = transform.position;
    }

    public void playAudio (int clip) {
        audioc.clip = audioClip[clip];
        audioc.Play ();
    }

    private void SetAllBoxColliders (bool state) {
        c[0].enabled = state;
        c[1].enabled = state;
    }
    
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
            SetAllBoxColliders (true);
        }
        if (GameController.allowMovement == true) {
            if (isAttacking == false) {
                if (mvBack == true) {
                    anim.SetTrigger ("wkBack");
                    anim.ResetTrigger ("idle");
                    //SetAllBoxColliders (false);

                } else {
                    anim.SetTrigger ("idle");
                    anim.ResetTrigger ("wkBack");
                }

                if (mvFwd == true) {
                    anim.SetTrigger ("wkFwd");
                    anim.ResetTrigger ("idle");
                    // SetAllBoxColliders (false);

                } else if (mvBack == false) {
                    anim.SetTrigger ("idle");
                    anim.ResetTrigger ("wkFwd");
                }
            } else if (isAttacking == true) {

                //if attacking, the colliders will be reenabled for her.
                SetAllBoxColliders (true);
            }
        }

    }

    public void punch () {
        isAttacking = true;
        anim.ResetTrigger ("idle");
        anim.SetTrigger ("punch");
        playAudio (1);
    }
    public void kick () {
        isAttacking = true;
        anim.ResetTrigger ("idle");
        anim.SetTrigger ("kick");
        playAudio (3);
    }
    public void react () {
        isAttacking = true;
        health = health - 10;
        if (health < 10) {
            knockout ();
            playAudio (2);
        } else {
            anim.ResetTrigger ("idle");
            anim.SetTrigger ("react");
            playAudio (0);
        }
        playerHB.value = health;
    }

    public void knockout () {
        GameController.allowMovement = false;
        //reset health as well in the beginning of each round.
        health = 100;
        anim.SetTrigger ("knockout");
        //if knocked out, add the score to the bear.
        GameController.instance.scoreEnemy ();
        GameController.instance.onScreenPoints ();
        GameController.instance.rounds ();
        if (GameController.enemyScore == 2) {
            StartCoroutine(showGameOver());
           // GameController.instance.doReset ();
           // StartCoroutine (resetCharacters ());
        } else { 
            StartCoroutine (resetCharacters ());
        }
    }
        IEnumerator showGameOver () {
        yield return new WaitForSeconds (0.3f);
        canvas.SetActive(true);
    }

    IEnumerator resetCharacters () {
        yield return new WaitForSeconds (4);
        canvas.SetActive(false);
        playerHB.value = 100;
        //when the game starts reset position
        Transform t = this.GetComponent<Transform> ();
        anim.SetTrigger("idle");
        anim.ResetTrigger("knockout");
        t.position = playerPosition;
        Debug.Log("t position" + t.position);
        t.position = new Vector3 (t.position.x, 0.001f, t.position.z);
        GameController.allowMovement = true;
    }
}