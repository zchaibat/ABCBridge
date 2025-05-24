using UnityEngine;
using UnityEngine.EventSystems;

public class AnchorPointClick : MonoBehaviour, IPointerDownHandler
{
    public BarCreator barCreator;

    private void Start()
    {
        if (barCreator == null)
            barCreator = FindObjectOfType<BarCreator>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            barCreator.TryStartOrEndBar(GetComponent<AnchorPoint>());
        else if (eventData.button == PointerEventData.InputButton.Right)
            barCreator.CancelBar();
    }
}
