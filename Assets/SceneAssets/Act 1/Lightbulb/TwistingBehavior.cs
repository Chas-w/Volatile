using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class TwistingBehavior : MonoBehaviour
{
    bool isMixing;
    bool isInRange;
    public Transform orb;
    public float radius;
    public float totalRotation;

    private Transform pivot;
    private float lastAngle;

    //GameObjects
    [SerializeField] GameObject mouseTracker;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isMixing = true;
        pivot = orb.transform;
        transform.parent = pivot;
        transform.position += Vector3.up * radius;

        lastAngle = 0;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = mouseTracker.transform.position;


        Vector2 MouseToOrb = new Vector2(mousePosition.x - orb.transform.position.x, mousePosition.y - orb.transform.position.y);

        //Reset to fit radius of the bowl
        if (MouseToOrb.magnitude < 2.5) isInRange = true; else isInRange = false;

        if (isMixing && isInRange && Input.GetMouseButton(0))
        {
            Vector3 orbVector = Camera.main.WorldToScreenPoint(orb.position);
            orbVector = Input.mousePosition - orbVector;
            float angle = Mathf.Atan2(orbVector.y, orbVector.x) * Mathf.Rad2Deg;

            pivot.position = orb.position;
            pivot.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

            if (lastAngle != angle)
            {
                totalRotation += Mathf.Abs(angle) / 1000;
                lastAngle = angle;
            }

        }
    }
}
