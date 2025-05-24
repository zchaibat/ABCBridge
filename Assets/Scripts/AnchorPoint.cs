using System.Collections.Generic;
using UnityEngine;

// Script pour les points qui relient les poutres ensemble

public class AnchorPoint : MonoBehaviour
{
    public List<Bar> BarresConnect�es = new List<Bar>();
    public bool Runtime = true;

    private void Update()
    {

        // Ce code fait en sorte qu'un point reste align� avec le quadrillage (Marche pas pr�sentement � cause d'un bug avec les points qui fait qu'ils tombent et ne restent pas fixes)

        if (!Runtime && transform.hasChanged)
        {
            transform.hasChanged = false;
            transform.position = Vector3Int.RoundToInt(transform.position);
        }
    }
}
