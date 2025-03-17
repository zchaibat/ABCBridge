using UnityEngine;

public class BeamCreator : MonoBehaviour
{
    public GameObject beamPrefab; // Prefab de la poutre
    private GameObject currentBeam; // Poutre en cours de création
    private Vector2 startMousePos; // Position initiale du clic

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Clic gauche pour commencer
        {
            startMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentBeam = Instantiate(beamPrefab, startMousePos, Quaternion.identity);
        }

        if (Input.GetMouseButton(0) && currentBeam != null) // Maintien du clic pour ajuster
        {
            Vector2 currentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            UpdateBeam(currentMousePos);
        }

        if (Input.GetMouseButtonUp(0) && currentBeam != null) // Relâchement du clic pour valider
        {
            currentBeam = null;
        }
    }

    void UpdateBeam(Vector2 endPos)
    {
        Vector2 midPoint = (startMousePos + endPos) / 2; // Position au centre
        float distance = Vector2.Distance(startMousePos, endPos); // Longueur de la poutre
        float angle = Mathf.Atan2(endPos.y - startMousePos.y, endPos.x - startMousePos.x) * Mathf.Rad2Deg; // Angle

        currentBeam.transform.position = midPoint;
        currentBeam.transform.right = (endPos - startMousePos).normalized; // Orientation
        currentBeam.transform.localScale = new Vector3(distance, 0.2f, 1f); // Ajustement taille (0.2 = épaisseur)
    }
}