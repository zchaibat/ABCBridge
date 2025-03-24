using UnityEngine;

public class Vehicule : MonoBehaviour
{
    public float acceleration = 0f;
    private float vitesse = 0f;
    public float vitesseMax = 10f;

    private Vector3 vecteurVitesse = Vector3.zero;
    private Rigidbody rb;

    public WheelCollider roueAvantGauche;
    public WheelCollider roueAvantDroite;
    public WheelCollider roueArriereGauche;
    public WheelCollider roueArriereDroite;

    public Transform roueAvantGaucheTransform;
    public Transform roueAvantDroiteTransform;
    public Transform roueArriereGaucheTransform;
    public Transform roueArriereDroiteTransform;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Set the Rigidbody settings
        rb.useGravity = true;
        rb.drag = 1f; // Slight drag to simulate resistance
        rb.angularDrag = 1f; // Slight angular drag
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous; // To prevent tunneling
        rb.interpolation = RigidbodyInterpolation.Interpolate; // To smooth physics
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            acceleration = 5f;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            acceleration = -5f;
        }
        else
        {
            acceleration = 0f;
        }

        vitesse += acceleration * Time.deltaTime;
        vitesse = Mathf.Clamp(vitesse, -vitesseMax, vitesseMax);

        vecteurVitesse = transform.forward * vitesse;

        roueAvantGauche.motorTorque = vitesse;
        roueAvantDroite.motorTorque = vitesse;

        UpdateWheelPosition(roueAvantGauche, roueAvantGaucheTransform);
        UpdateWheelPosition(roueAvantDroite, roueAvantDroiteTransform);
        UpdateWheelPosition(roueArriereGauche, roueArriereGaucheTransform);
        UpdateWheelPosition(roueArriereDroite, roueArriereDroiteTransform);

        rb.velocity = new Vector3(vecteurVitesse.x, rb.velocity.y, vecteurVitesse.z);
    }

    void UpdateWheelPosition(WheelCollider collider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        collider.GetWorldPose(out pos, out rot);
        wheelTransform.position = pos;
        wheelTransform.rotation = rot;
    }
}
