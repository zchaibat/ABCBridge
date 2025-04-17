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
        if (BarCreationStarted == false)
        {
            BarCreationStarted = true;
            StartBarCreation(Vector2Int.RoundToInt(Camera.main.ScreenToWorldPoint(eventData.position)));
        }
        else
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                FinishBarCreation();
            }
            else if (eventData.button == PointerEventData.InputButton.Right)
            {
                BarCreationStarted = false;
                DeleteCurrentBar();
            }
        }
    }

    void StartBarCreation(Vector2 startPosition)
    {
        CurrentBar = Instantiate(BarToInstantiate, startPosition, Quaternion.identity, BarParent).GetComponent<Bar>();
        CurrentBar.StartPosition = startPosition;

        CurrentStartPoint = Instantiate(PointToInstantiate, startPosition, Quaternion.identity, PointParent).GetComponent<AnchorPoint>();
        CurrentEndPoint = Instantiate(PointToInstantiate, startPosition, Quaternion.identity, PointParent).GetComponent<AnchorPoint>();
    }

    void FinishBarCreation()
    {
        CurrentStartPoint.ConnectedBars.Add(CurrentBar);
        CurrentEndPoint.ConnectedBars.Add(CurrentBar);
        StartBarCreation(CurrentEndPoint.transform.position);
    }

    void DeleteCurrentBar()
    {
        Destroy(CurrentBar.gameObject);

        if (CurrentStartPoint.ConnectedBars.Count == 0 && CurrentStartPoint.Runtime == true)
        {
            Destroy(CurrentStartPoint.gameObject);
        }

        if (CurrentEndPoint.ConnectedBars.Count == 0 && CurrentEndPoint.Runtime == true)
        {
            Destroy(CurrentEndPoint.gameObject);
        }
    }

    private void Update()
    {
        if (BarCreationStarted == true)
        {
            CurrentEndPoint.transform.position = (Vector2)Vector2Int.RoundToInt(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            CurrentBar.UpdateCreatingBar(CurrentEndPoint.transform.position);
        }
    }
    public void TryStartOrEndBar(Vector2 position)
    {
        if (!BarCreationStarted)
        {
            BarCreationStarted = true;
            StartBarCreation(position);
        }
        else
        {
            FinishBarCreation();
        }
    }
    public void CancelBar()
    {
        BarCreationStarted = false;
        DeleteCurrentBar();
    }
}
