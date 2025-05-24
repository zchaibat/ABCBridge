using System.Collections.Generic;
using UnityEngine;

// Script pas utilisé dans le projet, je ne suis pas l'auteur de ce code et donc, je ne peux pas l'expliquer...

public class SimulationManager : MonoBehaviour
{
    public List<Rigidbody2D> bodiesToActivate = new List<Rigidbody2D>();
    public bool isSimulating = false;

    public void AddBody(Rigidbody2D body)
    {
        if (!bodiesToActivate.Contains(body))
            bodiesToActivate.Add(body);
    }

    public void StartSimulation()
    {
        foreach (Rigidbody2D rb in bodiesToActivate)
        {
            rb.simulated = true;
        }
        isSimulating = true;
    }

    public void ResetSimulation()
    {
        foreach (Rigidbody2D rb in bodiesToActivate)
        {
            rb.simulated = false;
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
        isSimulating = false;
    }
}
