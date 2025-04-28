using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class Niveau : MonoBehaviour
{
    public float budget;
    public GameObject texteBudget;
    public Material quadrillage;
    public Camera camera;

    private Boolean modeConstruction = true;
    private Boolean modeDeboguage = false;

    
    public void Start()
    {

        float tailleCarre = (float) (15 / camera.orthographicSize);

        print(tailleCarre);

        float tailleCercle = (float) (1 / tailleCarre);

        quadrillage.SetFloat("_carresParMetres",  tailleCarre);
        texteBudget.GetComponent<TextMeshProUGUI>().SetText(budget.ToString() + "$");




    }

    // Update is called once per frame
    public void Update()
    {
        
    }
}
