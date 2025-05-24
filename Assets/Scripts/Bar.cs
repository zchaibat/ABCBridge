using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]

// Script qui gère les poutres (la liaison entre les poutres, les colliders, la position)

public class Bar : MonoBehaviour
{
    public Vector2 positionDepart;
    public SpriteRenderer barSpriteRenderer;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        barSpriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    public void UpdateCreatingBar(Vector2 ToPosition)
    {
        // Positionner la poutre entre les deux points
        transform.position = (ToPosition + positionDepart) / 2;

        // Calculer direction et angle
        Vector2 dir = ToPosition - positionDepart;
        float angle = Vector2.SignedAngle(Vector2.right, dir);
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

        // Ajuster la taille visuelle
        float length = dir.magnitude;
        barSpriteRenderer.size = new Vector2(length, barSpriteRenderer.size.y);

        // Adapter aussi le BoxCollider2D à la taille de la poutre
        if (boxCollider != null)
        {
            boxCollider.size = new Vector2(length, barSpriteRenderer.size.y);
            boxCollider.offset = Vector2.zero;
        }
    }
    private void Start()
    {
        // Enregistrer dans la simulation
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.simulated = false;
            SimulationManager simMgr = FindObjectOfType<SimulationManager>();
            if (simMgr != null)
            {
                simMgr.AddBody(rb);
            }
        }
    }
    public void ConnectTo(Rigidbody2D startBody, Rigidbody2D endBody)
{
    Rigidbody2D rb = GetComponent<Rigidbody2D>();

    DistanceJoint2D jointA = gameObject.AddComponent<DistanceJoint2D>();
    jointA.connectedBody = startBody;
    jointA.autoConfigureDistance = false;
    jointA.distance = Vector2.Distance(startBody.position, rb.position);
    jointA.enableCollision = false;

    DistanceJoint2D jointB = gameObject.AddComponent<DistanceJoint2D>();
    jointB.connectedBody = endBody;
    jointB.autoConfigureDistance = false;
    jointB.distance = Vector2.Distance(endBody.position, rb.position);
    jointB.enableCollision = false;
}

}
