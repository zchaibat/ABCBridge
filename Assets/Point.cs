using UnityEngine;

public class Point : MonoBehaviour
{

    private readonly double coordonneX;
    private readonly double coordonneY;
    private readonly double coordonneZ = -5;

    public Point(double coordonneX, double coordonneY)
    {
        this.coordonneX = coordonneX;
        this.coordonneY = coordonneY;   
    }

    public double getCoordonneX()
    {
        return coordonneX;
    }

    public double getCoordonneY()
    {
        return coordonneY;
    }

}
