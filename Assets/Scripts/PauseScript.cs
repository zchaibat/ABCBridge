using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Script qui gère le temps dans le jeu pour faire (pause/continuer)

public class PauseMenu : MonoBehaviour
{

    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject optionsMenu;

    public static bool jeuPause = false;

    public void Pause()
    {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            jeuPause = true;
    }


    public void Resume()
    {
        
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            jeuPause = false;
        
    }

    public void Options()
    {

        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true);


    }

    public void fermerOptions()
    {

        optionsMenu.SetActive(false);
        pauseMenu.SetActive(true);


    }

    public void RetourMenu(String nomScene)
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(nomScene);
    }

     void Update(){
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            

            if (jeuPause == true)
            {
                Resume();
            }
            else 
            {
                Pause();
            }
        }
    }
}
