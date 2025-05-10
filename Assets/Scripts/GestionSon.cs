using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GestionSon : MonoBehaviour
{
    [SerializeField] Slider curseurVolume;

    // D�marrage au lancement de la sc�ne
    void Start()
    {
        if (!PlayerPrefs.HasKey("volumeMusique"))
        {
            PlayerPrefs.SetFloat("volumeMusique", 1);
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
