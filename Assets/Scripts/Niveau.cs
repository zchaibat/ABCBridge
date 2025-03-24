using System;
using UnityEngine;

public class Niveau : MonoBehaviour
{
    public Camera camera;
    public GameObject grillePoints;

    private const float distanceEntrePoints = 0.5f;
    

    // Start is called before the first frame update
    public void creerNiveau()
    {
        Debug.Log("creer niveau");

        Point pointAncre1 = new Point(-30, -10, grillePoints.transform);
        Point pointAncre2 = new Point(30, 10, grillePoints.transform);

        var distanceEntrePointsAncres = pointAncre1.getCoordonneX() - pointAncre2.getCoordonneX();

        var x = 0.0f;

        while(x < distanceEntrePointsAncres)
        {

            var y = -camera.orthographicSize;

            while(y < Math.Abs(y))
            {
                new Point(x, y, grillePoints.transform);
                y += distanceEntrePoints;
            }

            x += distanceEntrePointsAncres; 
        }
        
    }

    // Update is called once per frame
    public void Update()
    {
        
    }
}
