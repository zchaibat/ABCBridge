using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleScript : MonoBehaviour
{
    public GameObject consigne;
    bool estVisible = false;


    public void AlternerAffichage()
    {
        // Inverse l'�tat de visibilit�
        estVisible = !estVisible;

        // Affiche ou cache l'image selon l'�tat actuel
        consigne.SetActive(estVisible);
    }
}
