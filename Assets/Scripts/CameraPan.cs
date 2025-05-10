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
            // Lock the Z position to avoid unintended diagonal movement
            Vector3 positionActuelle = transform.position;
            Vector3 targetPosition = new Vector3(ciblePosition.x, positionActuelle.y, positionActuelle.z);

            print(targetPosition);
            // Move the camera smoothly on the X-axis only
            transform.position = Vector3.MoveTowards(positionActuelle, ciblePosition, vitesse * Time.deltaTime);

            print("my curent positon is " + positionActuelle.x);
            print("my target postion  is " + ciblePosition.x);
            print("the distanc ebetwtenn is " + (positionActuelle.x - ciblePosition.x));


            // Check if the camera reached the target X position
            if (Mathf.Abs(transform.position.x - 20) < 0.01f)
            {
                activer = false;
                Debug.Log("Camera a atteint la position cible: " + transform.position);
            }
        }
    }
    public void activerBouton()
    {
        activer = !activer;
        print(activer);
    }


}

