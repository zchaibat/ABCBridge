using UnityEngine;

public class Point : MonoBehaviour
{
    public GameObject prefabPoint;

    private GameObject point;
    private readonly float coordonneX;
    private readonly float coordonneY;

    private Vector3 position;

    public Point(float coordonneX, float coordonneY, Transform tr)
    {
        Debug.Log("nouveau point");
        this.coordonneX = coordonneX;
        this.coordonneY = coordonneY;  

        position = new Vector3(coordonneX, coordonneY, 0);

        point = Instantiate(prefabPoint, position, Quaternion.identity, tr);
    }

    public float getCoordonneX()
    {
        return coordonneX;
    }

    public float getCoordonneY()
    {
        return coordonneY;
        
    }

}
