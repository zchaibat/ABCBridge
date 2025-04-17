using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleVoiture : MonoBehaviour
{
    private float entreeHorizontale, entreeVerticale;
    private float angleDirectionActuel, forceFreinageActuelle;
    private bool estEnFreinage;
    

    [SerializeField] private float forceMoteur, forceFreinage, angleMaxDirection;


    [SerializeField] private WheelCollider roueAvantGaucheCollider, roueAvantDroiteCollider;
    [SerializeField] private WheelCollider roueArriereGaucheCollider, roueArriereDroiteCollider;


    [SerializeField] private Transform roueAvantGaucheTransform, roueAvantDroiteTransform;
    [SerializeField] private Transform roueArriereGaucheTransform, roueArriereDroiteTransform;

    private void FixedUpdate()
    {
        ObtenirEntrees();
        GererMoteur();
        MettreAJourRoues();
    }

    private void ObtenirEntrees()
    {
       
        entreeVerticale = Input.GetAxis("Horizontal");

        estEnFreinage = Input.GetKey(KeyCode.Space);
    }

    private void GererMoteur()
    {
        roueAvantGaucheCollider.motorTorque = entreeVerticale * forceMoteur;
        roueAvantDroiteCollider.motorTorque = entreeVerticale * forceMoteur;
        forceFreinageActuelle = estEnFreinage ? forceFreinage : 0f;
        AppliquerFreinage();
    }

    private void AppliquerFreinage()
    {
        roueAvantDroiteCollider.brakeTorque = forceFreinageActuelle;
        roueAvantGaucheCollider.brakeTorque = forceFreinageActuelle;
        roueArriereGaucheCollider.brakeTorque = forceFreinageActuelle;
        roueArriereDroiteCollider.brakeTorque = forceFreinageActuelle;
    }

    private void MettreAJourRoues()
    {
        MettreAJourRoueUnique(roueAvantGaucheCollider, roueAvantGaucheTransform);
        MettreAJourRoueUnique(roueAvantDroiteCollider, roueAvantDroiteTransform);
        MettreAJourRoueUnique(roueArriereDroiteCollider, roueArriereDroiteTransform);
        MettreAJourRoueUnique(roueArriereGaucheCollider, roueArriereGaucheTransform);
    }

    private void MettreAJourRoueUnique(WheelCollider colliderRoue, Transform transformRoue)
    {
        Vector3 position;
        Quaternion rotation;
        colliderRoue.GetWorldPose(out position, out rotation);
        transformRoue.rotation = rotation;
        transformRoue.position = position;
    }
}
