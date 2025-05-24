using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Script qui gère le son (Musique et Effets de son qui n'ont pas été implémenté)

public class GestionSon : MonoBehaviour
{
    [SerializeField] Slider curseurVolume;

    // Démarrage au lancement de la scène
    void Start()
    {
        if (!PlayerPrefs.HasKey("volumeMusique"))
        {
            PlayerPrefs.SetFloat("volumeMusique", 0.5f);
            Charger();
        }
        else
        {
            Charger();
        }
    }

    public void ChangerVolume()
    {
        AudioListener.volume = curseurVolume.value;
        Sauvegarder();
    }

    private void Charger()
    {
        curseurVolume.value = PlayerPrefs.GetFloat("volumeMusique");
    }

    private void Sauvegarder()
    {
        PlayerPrefs.SetFloat("volumeMusique", curseurVolume.value);
    }
}
