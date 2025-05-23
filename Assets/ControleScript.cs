using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleScript : MonoBehaviour
{
    public GameObject consigne;
    bool estVisible = false;


    public void AlternerAffichage()
    {
        // Inverse l'état de visibilité
        estVisible = !estVisible;

        // Affiche ou cache l'image selon l'état actuel
        consigne.SetActive(estVisible);
    }
}
