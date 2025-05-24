using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script qui fait tourner les nuages dans le menu principal pour le rendre plus dynamique

public class rotationMenu : MonoBehaviour
{
    [SerializeField] private Vector3 rotation;

    public Material rotationMateriel;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotation * Time.deltaTime);

    }
}
