using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Continue : MonoBehaviour
{
    // Start is called before the first frame update
   
    public void goToFight() {
        SceneManager.LoadScene("Spielraum_2");
    }

    public void QuitFight() {
        Application.Quit();
    }
}

