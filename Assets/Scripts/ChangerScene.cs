using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class BoutonScript : MonoBehaviour
{
    public void changerScene()
    {
        SceneManager.LoadScene("Scenes/testScene");
    }

    
    
}
