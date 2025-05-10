using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BougerCamera : MonoBehaviour
{
    public float vitesse =  10;
    public Vector3 ciblePosition = new Vector3(20, 0, -20);  

    bool activer = false;

    void Update()
    {
        if (activer)
        {
            transform.position = Vector3.MoveTowards(transform.position, ciblePosition, vitesse * Time.deltaTime);

            if (Vector3.Distance(transform.position, ciblePosition) < 0.01f)
            {
                activer = false;
            }
        }
    }
    public void activerBouton(Vector3 nouvellePosition)
    {
        ciblePosition = nouvellePosition;
        activer = !activer;
        print(activer);
    }
    public void positionJouer()
    {
        activerBouton(new Vector3(20, 0, -20));
    }

    public void positionOption()
    {
        activerBouton(new Vector3(0, 12, -20));
    }

    public void positionInitial()
    {
        activerBouton(new Vector3(0, 0, -20));
    }

}

