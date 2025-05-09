using UnityEngine;

public class RotateSnake : MonoBehaviour
{
    [SerializeField] float rotationSpeed;

    //bool isRotating;
    bool canRotate;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canRotate && Input.GetMouseButton(0)) {
            this.transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime));
        }
    }

    private void OnMouseEnter()
    {
        canRotate = true;
    }

    private void OnMouseExit()
    {
        canRotate = false;
    }
}
