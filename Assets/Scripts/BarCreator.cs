using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// Script qui gère la création d'une poutre

public class BarCreator : MonoBehaviour, IPointerDownHandler
{
    bool creationCommencee = false;
    public Bar barreActuelle;
    public GameObject prefabBarre;
    public Transform conteneurPoutres;
    public AnchorPoint pointDepart;
    public AnchorPoint pointFinal;
    public GameObject prefabPoint;
    public Transform conteneurPoints;

    public void OnPointerDown(PointerEventData eventData)
    {
        // Ne rien faire sur clic dans le vide
    }

    void CommencerCreationBarre(Vector2 startPosition)
    {
        GameObject barGO = Instantiate(prefabBarre, startPosition, Quaternion.identity, conteneurPoutres);
        barreActuelle = barGO.GetComponent<Bar>();
        barreActuelle.positionDepart = startPosition;

        GameObject endPointGO = Instantiate(prefabPoint, startPosition, Quaternion.identity, conteneurPoints);
        pointFinal = endPointGO.GetComponent<AnchorPoint>();

        // Changer le BodyType en Dynamic pour les points créés en cours de jeu
        Rigidbody2D endPointRB = pointFinal.GetComponent<Rigidbody2D>();

        if (endPointRB != null)
        {
        endPointRB.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    void FinirCreationBarre()
    {
        pointDepart.BarresConnectées.Add(barreActuelle);
        pointFinal.BarresConnectées.Add(barreActuelle);

        barreActuelle.UpdateCreatingBar(pointFinal.transform.position);

        // On redémarre automatiquement une nouvelle poutre depuis le point final
        pointDepart = pointFinal;
        CommencerCreationBarre(pointFinal.transform.position);

        // Connecter la poutre aux deux points
        Rigidbody2D startRb = pointDepart.GetComponent<Rigidbody2D>();
        Rigidbody2D endRb = pointFinal.GetComponent<Rigidbody2D>();
        barreActuelle.ConnectTo(startRb, endRb);

    }


    public void CancelBarre()
    {
        creationCommencee = false;

        if (barreActuelle != null)
            Destroy(barreActuelle.gameObject);

        // Supprime le point temporaire s'il a été créé dynamiquement
        if (pointFinal != null && pointFinal.BarresConnectées.Count == 0 && pointFinal.Runtime)
            Destroy(pointFinal.gameObject);

        barreActuelle = null;
        pointFinal = null;
        // Ne touche pas à pointDepart ici
    }


    void SupprimerBarre()
    {
        if (barreActuelle != null)
            Destroy(barreActuelle.gameObject);

        if (pointFinal != null && pointFinal.BarresConnectées.Count == 0 && pointFinal.Runtime)
            Destroy(pointFinal.gameObject);

        // Ne pas supprimer StartPoint : il n’a jamais été instancié dynamiquement ici

        barreActuelle = null;
        pointFinal = null;
        pointDepart = null;
    }

    private void Update()
    {
        if (creationCommencee && pointFinal != null && barreActuelle != null)
        {
            Vector2 mousePos = Vector2Int.RoundToInt(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            pointFinal.transform.position = mousePos;
            barreActuelle.UpdateCreatingBar(mousePos);
        }
    }

    public void EssayerCreerPoutre(AnchorPoint clickedPoint)
    {
        if (!creationCommencee)
        {
            creationCommencee = true;
            pointDepart = clickedPoint;
            CommencerCreationBarre(clickedPoint.transform.position);
        }
        else
        {
            if (clickedPoint == pointDepart)
            {
                CancelBarre();
                return;
            }

            pointFinal = clickedPoint;
            FinirCreationBarre();
        }
    }
}
