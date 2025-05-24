using UnityEngine;
using UnityEngine.UI;
using TMPro;  // Pour TextMeshPro
using System.IO;

// Script qui génère les boutons dans le menu principal qui amènent à la scène de jeu à partir d'un dossier avec des GameObjects qui représentent les niveaux

public class CreationNiveaux : MonoBehaviour
{
    public GameObject prefabBouton;
    public Transform conteneurBoutons;

    public float positionXInitiale = -300f;
    public float bondX = 200f;
    public float positionY = 160.45f;
    public float bondY = 100f;
    public int boutonsParLigne = 4;

    public string dossierNiveaux = "Assets/Niveaux";

    void Start()
    {
        if (prefabBouton == null)
        {
            Debug.LogError("le prefab du bouton n'est pas assigné dans l'inspector.");
            return;
        }
        if (conteneurBoutons == null)
        {
            Debug.LogError("le conteneur de boutons n'est pas assigné.");
            return;
        }

        int nombreBoutons = CompterElementsDansDossier(dossierNiveaux);
        Debug.Log("le nombre d'éléments dans le dossier 'Niveaux' : " + nombreBoutons);
        GenererBoutons(nombreBoutons);
    }

    int CompterElementsDansDossier(string dossier)
    {
        if (!Directory.Exists(dossier))
        {
            Debug.LogError("dossier pas trouvé : " + dossier);
            return 0;
        }

        string[] fichiers = Directory.GetFiles(dossier);

        return fichiers.Length/2;
    }

    void GenererBoutons(int nombreBoutons)
    {
        int colonne = 0;
        int ligne = 0;

        for (int i = 0; i < nombreBoutons; i++)
        {
            //génère un bouton
            GameObject bouton = Instantiate(prefabBouton, conteneurBoutons);

            float posX = positionXInitiale + (colonne * bondX);
            float posY = positionY - (ligne * bondY);

            //pour position les boutons dans le canvas
            RectTransform rectTransform = bouton.GetComponent<RectTransform>();
            if (rectTransform != null)
            {
                rectTransform.anchoredPosition = new Vector3(posX, posY, 0);
            }

            //lit textmeshpro
             TextMeshProUGUI tmpText = bouton.GetComponentInChildren<TextMeshProUGUI>();
            if (tmpText != null)
            {
                int temp = i + 1;
                tmpText.text = temp.ToString();
            }
             
            else
            {
                Debug.LogError("on ne trouve pas de text ou textmeshpro ");
            }
            
            //événement cliquer sur les boutons niveaux
            int index = i + 1;
            Button buttonComponent = bouton.GetComponent<Button>();
            if (buttonComponent != null)
            {
                buttonComponent.onClick.AddListener(() => BoutonClique(index));
            }


            //génère un autre colonne si le nombre de bouton dépasse 4
            colonne++;
            if (colonne >= boutonsParLigne)
            {
                colonne = 0;
                ligne++;
            }
        }
    }

    void BoutonClique(int numero)
    {
        Debug.Log("Bouton cliqué : Niveau " + numero);
    }
}
