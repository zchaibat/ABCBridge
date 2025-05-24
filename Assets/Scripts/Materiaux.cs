using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script pas implémenté dans le projet à cause du blocage sur le code de la physique, on n'a pas pu aller de l'avant avec les matériaux, car les bugs avec le pont nous retenaient

public abstract class MateriauPont
{
    public string Nom { get; protected set; }
    public float CoutParMetre { get; protected set; }
    public float TensionMax { get; protected set; }
    public float CompressionMax { get; protected set; }
    public float PoidsParUnite { get; protected set; }

    public abstract void UtiliserMateriau();  // Méthode de comportement
}

public class Bois : MateriauPont
{
    public Bois()
    {
        Nom = "Bois";
        CoutParMetre = 5.0f;
        TensionMax = 100f;
        CompressionMax = 100f;
        PoidsParUnite = 1.0f;
    }

    public override void UtiliserMateriau()
    {
        Console.WriteLine("Utilisation du bois : bon marché mais fragile.");
    }
}
public class Acier : MateriauPont
{
    public Acier()
    {
        Nom = "Acier";
        CoutParMetre = 15.0f;
        TensionMax = 500f;
        CompressionMax = 500f;
        PoidsParUnite = 2.5f;
    }

    public override void UtiliserMateriau()
    {
        Console.WriteLine("Utilisation de l'acier : solide et fiable.");
    }
}

public class Beton : MateriauPont
{
    public Beton()
    {
        Nom = "Béton";
        CoutParMetre = 20.0f;
        TensionMax = 50f;      
        CompressionMax = 1000f;  
        PoidsParUnite = 3.0f;
    }

    public override void UtiliserMateriau()
    {
        Console.WriteLine("Utilisation du béton : excellent pour les supports.");
    }
}

public class FibreDeCarbone : MateriauPont
{
    public FibreDeCarbone()
    {
        Nom = "Fibre de Carbone";
        CoutParMetre = 50.0f;  
        TensionMax = 1500f;   
        CompressionMax = 1200f; 
        PoidsParUnite = 0.5f;  
    }

    public override void UtiliserMateriau()
    {
        Console.WriteLine("Utilisation de la fibre de carbone : très légère et extrêmement solide.");
    }
}



public class Asphalte : MateriauPont
{

    public Asphalte()
    {
        Nom = "Asphalte";
        CoutParMetre = 10.0f;
        TensionMax = 200f;
        CompressionMax = 300f;
        PoidsParUnite = 2.0f;
    }

    public override void UtiliserMateriau()
    {
        Console.WriteLine("Utilisation de l'asphalte : idéal pour les routes.");
    }

}


