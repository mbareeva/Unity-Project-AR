using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Transform canvas;
    private bool isClicked = false;
    // Start is called before the first frame update

    // Update is called once per frame
    public void activatePause() {
        Time.timeScale = 0;
        canvas.gameObject.SetActive(true);
    }

    public void disactivatePause() {
        Time.timeScale = 1;
        canvas.gameObject.SetActive(false);
        isClicked = false;
    }

    public void restart () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMenu() {
        SceneManager.LoadScene("Hauptmenu");
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            isClicked = !isClicked;
        }

        if(isClicked) {
            activatePause();
        } else {
            disactivatePause();
        }
    }
}

