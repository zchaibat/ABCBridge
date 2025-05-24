using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

// Script qui gère la logique de la scène de jeu (Création d'un niveau (pas finie), commencer/pause, budget, taille de la camera, du quadrillage et des points)

public class Niveau : MonoBehaviour
{
    public GameObject texteBudget;
    public Material quadrillage;
    public Camera camera;
    private Boolean modeDeboguage = false;
    public GameObject pointReference;

    public GameObject vehicule;
    public GameObject mapGauche;
    public GameObject mapDroite;
    public float budget;
   


    public void Start()
    {
        Time.timeScale = 0;

        float tailleCarre = (float) (15 / camera.orthographicSize);

        float tailleCercle = 1/tailleCarre;
        pointReference.transform.localScale = new Vector3(tailleCercle, tailleCercle, tailleCercle);

        quadrillage.SetFloat("_carresParMetres",  tailleCarre);
        texteBudget.GetComponent<TextMeshProUGUI>().SetText(budget.ToString() + "$");

    }

    public void commencerPartie()
    {
        Time.timeScale = 1;
    }

    public void pausePartie()
    {
        
        Time.timeScale = 0;
    }



    // Update is called once per frame
    public void Update()
    {
    }
}
