using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicule6Roues : MonoBehaviour
{
    private float entreeHorizontale;
    private float forceFreinageActuelle;
    private bool estEnFreinage;

    [SerializeField] private float forceMoteur;
    [SerializeField] private float forceFreinage;

    // Wheel Colliders
    [SerializeField] private WheelCollider roueAvantGaucheCollider, roueAvantDroiteCollider;
    [SerializeField] private WheelCollider roueMilieuGaucheCollider, roueMilieuDroiteCollider;
    [SerializeField] private WheelCollider roueArriereGaucheCollider, roueArriereDroiteCollider;

    // Wheel Meshes / Transforms
    [SerializeField] private Transform roueAvantGaucheTransform, roueAvantDroiteTransform;
    [SerializeField] private Transform roueMilieuGaucheTransform, roueMilieuDroiteTransform;
    [SerializeField] private Transform roueArriereGaucheTransform, roueArriereDroiteTransform;

    private void FixedUpdate()
    {
        ObtenirEntrees();
        GererMoteur();
        MettreAJourRoues();
    }

    private void ObtenirEntrees()
    {
        entreeHorizontale = Input.GetAxis("Horizontal");
        estEnFreinage = Input.GetKey(KeyCode.Space);
    }

    private void GererMoteur()
    {
        // Only drive the rear/mid wheels (typical for trucks)
        roueMilieuGaucheCollider.motorTorque = entreeHorizontale * forceMoteur;
        roueMilieuDroiteCollider.motorTorque = entreeHorizontale * forceMoteur;
        roueArriereGaucheCollider.motorTorque = entreeHorizontale * forceMoteur;
        roueArriereDroiteCollider.motorTorque = entreeHorizontale * forceMoteur;

        forceFreinageActuelle = estEnFreinage ? forceFreinage : 0f;
        AppliquerFreinage();
    }

    private void AppliquerFreinage()
    {
        roueAvantGaucheCollider.brakeTorque = forceFreinageActuelle;
        roueAvantDroiteCollider.brakeTorque = forceFreinageActuelle;
        roueMilieuGaucheCollider.brakeTorque = forceFreinageActuelle;
        roueMilieuDroiteCollider.brakeTorque = forceFreinageActuelle;
        roueArriereGaucheCollider.brakeTorque = forceFreinageActuelle;
        roueArriereDroiteCollider.brakeTorque = forceFreinageActuelle;
    }

    private void MettreAJourRoues()
    {
        MettreAJourRoueUnique(roueAvantGaucheCollider, roueAvantGaucheTransform);
        MettreAJourRoueUnique(roueAvantDroiteCollider, roueAvantDroiteTransform);

        MettreAJourRoueUnique(roueMilieuGaucheCollider, roueMilieuGaucheTransform);
        MettreAJourRoueUnique(roueMilieuDroiteCollider, roueMilieuDroiteTransform);

        MettreAJourRoueUnique(roueArriereGaucheCollider, roueArriereGaucheTransform);
        MettreAJourRoueUnique(roueArriereDroiteCollider, roueArriereDroiteTransform);
    }

    private void MettreAJourRoueUnique(WheelCollider colliderRoue, Transform transformRoue)
    {
        Vector3 position;
        Quaternion rotation;
        colliderRoue.GetWorldPose(out position, out rotation);
        transformRoue.position = position;
        transformRoue.rotation = rotation;
    }
}
