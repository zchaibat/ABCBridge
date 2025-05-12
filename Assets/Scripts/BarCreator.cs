using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BarCreator : MonoBehaviour, IPointerDownHandler
{
    bool BarCreationStarted = false;
    public Bar CurrentBar;
    public GameObject BarToInstantiate;
    public Transform BarParent;
    public AnchorPoint CurrentStartPoint;
    public AnchorPoint CurrentEndPoint;
    public GameObject PointToInstantiate;
    public Transform PointParent;

    public void OnPointerDown(PointerEventData eventData)
    {
        // Ne rien faire sur clic dans le vide
    }

    void StartBarCreation(Vector2 startPosition)
    {
        GameObject barGO = Instantiate(BarToInstantiate, startPosition, Quaternion.identity, BarParent);
        CurrentBar = barGO.GetComponent<Bar>();
        CurrentBar.StartPosition = startPosition;

        GameObject endPointGO = Instantiate(PointToInstantiate, startPosition, Quaternion.identity, PointParent);
        CurrentEndPoint = endPointGO.GetComponent<AnchorPoint>();

        // Changer le BodyType en Dynamic pour les points créés en cours de jeu
Rigidbody2D endPointRB = CurrentEndPoint.GetComponent<Rigidbody2D>();
if (endPointRB != null)
{
    endPointRB.bodyType = RigidbodyType2D.Dynamic;
}
    }

    void FinishBarCreation()
    {
        CurrentStartPoint.ConnectedBars.Add(CurrentBar);
        CurrentEndPoint.ConnectedBars.Add(CurrentBar);

        CurrentBar.UpdateCreatingBar(CurrentEndPoint.transform.position);

        // On redémarre automatiquement une nouvelle poutre depuis le point final
        CurrentStartPoint = CurrentEndPoint;
        StartBarCreation(CurrentEndPoint.transform.position);

        // Connecter la poutre aux deux points
        Rigidbody2D startRb = CurrentStartPoint.GetComponent<Rigidbody2D>();
        Rigidbody2D endRb = CurrentEndPoint.GetComponent<Rigidbody2D>();
        CurrentBar.ConnectTo(startRb, endRb);

    }


    public void CancelBar()
    {
        BarCreationStarted = false;

        if (CurrentBar != null)
            Destroy(CurrentBar.gameObject);

        // Supprime le point temporaire s'il a été créé dynamiquement
        if (CurrentEndPoint != null && CurrentEndPoint.ConnectedBars.Count == 0 && CurrentEndPoint.Runtime)
            Destroy(CurrentEndPoint.gameObject);

        CurrentBar = null;
        CurrentEndPoint = null;
        // Ne touche pas à CurrentStartPoint ici
    }


    void DeleteCurrentBar()
    {
        if (CurrentBar != null)
            Destroy(CurrentBar.gameObject);

        if (CurrentEndPoint != null && CurrentEndPoint.ConnectedBars.Count == 0 && CurrentEndPoint.Runtime)
            Destroy(CurrentEndPoint.gameObject);

        // Ne pas supprimer StartPoint : il n’a jamais été instancié dynamiquement ici

        CurrentBar = null;
        CurrentEndPoint = null;
        CurrentStartPoint = null;
    }

    private void Update()
    {
        if (BarCreationStarted && CurrentEndPoint != null && CurrentBar != null)
        {
            Vector2 mousePos = Vector2Int.RoundToInt(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            CurrentEndPoint.transform.position = mousePos;
            CurrentBar.UpdateCreatingBar(mousePos);
        }
    }

    public void TryStartOrEndBar(AnchorPoint clickedPoint)
    {
        if (!BarCreationStarted)
        {
            BarCreationStarted = true;
            CurrentStartPoint = clickedPoint;
            StartBarCreation(clickedPoint.transform.position);
        }
        else
        {
            if (clickedPoint == CurrentStartPoint)
            {
                CancelBar();
                return;
            }

            CurrentEndPoint = clickedPoint;
            FinishBarCreation();
        }
    }
}
