using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using System;

public class BoutonScript : MonoBehaviour
{
    public void changerScene(String sceneNom)
    {
        //"Scenes/testScene"
        SceneManager.LoadScene(sceneNom);
    }
    public void quitter()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    
    
}
