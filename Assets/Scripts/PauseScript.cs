using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject pauseMenu;

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
