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

    // Start is called before the first frame update
    public void Start()
    {

        Double tailleCarre = ((Double) (6/20))*camera.orthographicSize;

        quadrillage.SetFloat("_carresParMetres", (float) tailleCarre);
        texteBudget.GetComponent<TextMeshProUGUI>().SetText(budget.ToString() + "$");




    }

    // Update is called once per frame
    public void Update()
    {
        
    }
}
