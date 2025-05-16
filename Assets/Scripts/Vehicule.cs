using System;
using UnityEngine;

public class Vehicule : MonoBehaviour
{
    private float entreeHorizontale;
    private float forceFreinageActuelle;
    private bool estEnFreinage;

    [SerializeField] private float forceMoteur;
    [SerializeField] private float forceFreinage;
    [SerializeField] private float coefficientFrottement = 0.1f; // Frottement simple

    // Wheel Colliders
    [SerializeField] private WheelCollider roueAvantGaucheCollider, roueAvantDroiteCollider;
    [SerializeField] private WheelCollider roueArriereGaucheCollider, roueArriereDroiteCollider;

    // Wheel Meshes / Transforms
    [SerializeField] private Transform roueAvantGaucheTransform, roueAvantDroiteTransform;
    [SerializeField] private Transform roueArriereGaucheTransform, roueArriereDroiteTransform;

    // Roues pour le véhicule à 6 roues (optionnel)
    [SerializeField] private WheelCollider roueMilieuGaucheCollider, roueMilieuDroiteCollider;
    [SerializeField] private Transform roueMilieuGaucheTransform, roueMilieuDroiteTransform;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        ObtenirEntrees();
        GererMoteur();
        AppliquerFreinage();
        AppliquerFrottement();
        MettreAJourRoues();
    }

    private void ObtenirEntrees()
    {
        entreeHorizontale = Input.GetAxis("Horizontal");
        estEnFreinage = Input.GetKey(KeyCode.Space);
    }

    private void GererMoteur()
    {
        // Moteur appliqué uniquement sur les roues avant pour un véhicule classique
        roueAvantGaucheCollider.motorTorque = entreeHorizontale * forceMoteur;
        roueAvantDroiteCollider.motorTorque = entreeHorizontale * forceMoteur;

        // Si le véhicule a 6 roues, on applique le moteur aux roues arrière et au milieu également
        if (roueMilieuGaucheCollider != null && roueMilieuDroiteCollider != null)
        {
            roueMilieuGaucheCollider.motorTorque = entreeHorizontale * forceMoteur;
            roueMilieuDroiteCollider.motorTorque = entreeHorizontale * forceMoteur;
        }

        roueArriereGaucheCollider.motorTorque = entreeHorizontale * forceMoteur;
        roueArriereDroiteCollider.motorTorque = entreeHorizontale * forceMoteur;
    }

    private void AppliquerFreinage()
    {
        forceFreinageActuelle = estEnFreinage ? forceFreinage : 0f;

        roueAvantGaucheCollider.brakeTorque = forceFreinageActuelle;
        roueAvantDroiteCollider.brakeTorque = forceFreinageActuelle;
        roueArriereGaucheCollider.brakeTorque = forceFreinageActuelle;
        roueArriereDroiteCollider.brakeTorque = forceFreinageActuelle;

        // Appliquer le freinage aux roues du milieu si elles existent
        if (roueMilieuGaucheCollider != null && roueMilieuDroiteCollider != null)
        {
            roueMilieuGaucheCollider.brakeTorque = forceFreinageActuelle;
            roueMilieuDroiteCollider.brakeTorque = forceFreinageActuelle;
        }
    }

    private void AppliquerFrottement()
    {
        if (rb == null) return;

        Vector3 vitesseHorizontale = rb.velocity;
        vitesseHorizontale.y = 0f; // On ne freine que horizontalement

        Vector3 forceFrottement = -vitesseHorizontale.normalized * coefficientFrottement;
        rb.AddForce(forceFrottement, ForceMode.Acceleration);
    }

    private void MettreAJourRoues()
    {
        MettreAJourRoueUnique(roueAvantGaucheCollider, roueAvantGaucheTransform);
        MettreAJourRoueUnique(roueAvantDroiteCollider, roueAvantDroiteTransform);
        MettreAJourRoueUnique(roueArriereGaucheCollider, roueArriereGaucheTransform);
        MettreAJourRoueUnique(roueArriereDroiteCollider, roueArriereDroiteTransform);

        // Mettre à jour les roues du milieu si elles existent
        if (roueMilieuGaucheCollider != null && roueMilieuDroiteCollider != null)
        {
            MettreAJourRoueUnique(roueMilieuGaucheCollider, roueMilieuGaucheTransform);
            MettreAJourRoueUnique(roueMilieuDroiteCollider, roueMilieuDroiteTransform);
        }
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
