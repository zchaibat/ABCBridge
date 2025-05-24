using UnityEngine;
using UnityEngine.EventSystems;

// Script qui d�clenche la cr�ation d'une poutre quand un point est cliqu�

public class AnchorPointClick : MonoBehaviour, IPointerDownHandler
{
    public BarCreator createurPoutre;

    private void Start()
    {
        if (createurPoutre == null)
            createurPoutre = FindObjectOfType<BarCreator>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            createurPoutre.EssayerCreerPoutre(GetComponent<AnchorPoint>());
        else if (eventData.button == PointerEventData.InputButton.Right)
            createurPoutre.CancelBarre();
    }
}
