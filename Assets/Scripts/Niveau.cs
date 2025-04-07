using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Niveau : MonoBehaviour
{

    public Material quadrillage;

    // Start is called before the first frame update
    public void Start()
    {
        Debug.Log("creer niveau");

        quadrillage.SetFloat("_tiling", 5.0f);




    }

    // Update is called once per frame
    public void Update()
    {
        
    }
}
