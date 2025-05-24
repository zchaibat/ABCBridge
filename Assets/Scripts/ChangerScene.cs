using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using System;

// Script qui permet de changer de scène

public class BoutonScript : MonoBehaviour
{
    public void changerScene(String sceneNom)
    {
        SceneManager.LoadScene(sceneNom);
    }
    public void quitter()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    
    
}
