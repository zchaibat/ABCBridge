using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class Niveau : MonoBehaviour
{
    private Point pointAncre1 = new Point(-30,10);
    private Point pointAncre2 = new Point(30,20);
    private const double distanceEntrePoints = 0.5;
    

    // Start is called before the first frame update
    void creerNiveau()
    {

        var distanceEntrePointsAncres = pointAncre2.getCoordonneX() - pointAncre1.getCoordonneX();

        var x = 0.0;

        while(x < distanceEntrePointsAncres)
        {
            var y = -15.0;

            while(y < 15)
            {
                new Point(x, y);
                y += distanceEntrePoints;
            }



            x += distanceEntrePointsAncres; 
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
