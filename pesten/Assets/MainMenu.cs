using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Methode om het spel te starten
    public void PlayGame()
    {
        // Laadt de volgende scene in de build index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

     // Methode om het spel te verlaten
    public void QuitGame()
    {
        Debug.Log("QUIT!"); // laat een debugbericht zien in de console "QUIT!"
        Application.Quit(); //  sluit het spel
    }
}
