using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameStarter : MonoBehaviour
{
    public void StartGame() {
        SceneManager.LoadScene("SampleScene");
    }

    public void goToAbout() {
        SceneManager.LoadScene("About");
    }

    public void goToCredits()
    {
        SceneManager.LoadScene("CreditsMenu");
    }
}
