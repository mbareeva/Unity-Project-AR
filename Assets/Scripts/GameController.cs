using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    //singleton pattern dafür benutzen, suchen.
    public static GameController instance;
    public static bool allowMovement = false;
    private bool played = false;
    public AudioClip[] audioClip;
    AudioSource audioc;
    public static int playerScore = 0;
    //for enemy
    public static int enemyScore = 0;

    public GameObject[] points; //for points that are scored during the round.

    public static int round = 0;

    void Awake () {
        if (instance == null) {
            instance = this;
        }
    }
    void Start () {
        audioc = GetComponent<AudioSource> ();
    }
    /*
     * Plays the given audio track.
     */
    private void playAudioTrack (int clip) {
        audioc.clip = audioClip[clip];
        audioc.Play ();
    }

    public void scorePlayer () {
        playerScore++;
    }

    public void scoreEnemy () {
        enemyScore++;
    }

    public void doReset () {
        if (playerScore == 2) {
            playAudioTrack (6);
        } else {
            playAudioTrack (5);
        }
        //reset the health bars in the beginning of game
        fighterController.instance.playerHB.value = 100;
        fighterController.instance.health = 100;

        enemyController.instance.enemyHB.value = 100;
        enemyController.instance.enemyHealth = 100;

        playerScore = 0;
        enemyScore = 0;
        //remove all points from the screen when resetting

        StartCoroutine (restartGame ());
    }
    IEnumerator restartGame () {
        yield return new WaitForSeconds (4.5f);
        points[0].SetActive (false);
        points[1].SetActive (false);
        points[2].SetActive (false);
        points[3].SetActive (false);
        allowMovement = true;
        StartCoroutine (restartRoundAudio ());

    }
    IEnumerator restartRoundAudio () {
        yield return new WaitForSeconds (2);
        playAudioTrack (0);
    }
    void Update () {
        if (played == false) {
            played = true;
            StartCoroutine (round1 ());
        }
    }
    /*
     * Play the audio.
     */
    IEnumerator round1 () {
        yield return new WaitForSeconds (0);
        playAudioTrack (0);
        StartCoroutine (prepareYourself ());

    }
    /*
     * Play the audio "prepare yourself"
     */
    IEnumerator prepareYourself () {
        yield return new WaitForSeconds (1.7f);
        playAudioTrack (1);
        StartCoroutine (start321 ());
    }

    /*
     * Plays the countdown.
     */
    IEnumerator start321 () {
        yield return new WaitForSeconds (2f);
        playAudioTrack (2);
        StartCoroutine (allowplayerMovement ());
    }

    /*
     * Allows the movement of characters after countdown.
     */
    IEnumerator allowplayerMovement () {
        yield return new WaitForSeconds (5f);
        allowMovement = true;
        Debug.Log ("movement allowed:" + allowMovement);
    }

    /*
     * Shows the points when one of the player scores the point.
     * Maximum amount is 2 points per round.
     */
    public void onScreenPoints () {
        if (playerScore == 1) {
            points[0].SetActive (true);
        } else if (playerScore == 2) {
            points[1].SetActive (true);
        }

        if (enemyScore == 1) {
            points[2].SetActive (true);
        } else if (enemyScore == 2) {
            points[3].SetActive (true);
        }
    }

    public void rounds () {
        round = playerScore + enemyScore;
        if (round == 1) {
            playAudioTrack (3);
        }
        if (round == 2 && playerScore != 2 && enemyScore != 2) {
            playAudioTrack (4);
        }
    }
}