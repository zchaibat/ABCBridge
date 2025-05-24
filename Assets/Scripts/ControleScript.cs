using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script qui gère le menu aide/contrôles présent la scène de jeu

public class ControleScript : MonoBehaviour
{
    public GameObject consigne;
    bool estVisible = false;


    public void AlternerAffichage()
    {
        //Alterner la visiblité des consignes
        estVisible = !estVisible;

        //Afficher ou cacher l'image selon l'état actuel
        consigne.SetActive(estVisible);
    }
}
