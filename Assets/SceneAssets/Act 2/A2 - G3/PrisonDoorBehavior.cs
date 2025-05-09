using UnityEngine;

public class PrisonDoorBehavior : MonoBehaviour
{
    Camera cam;
    bool isHeld;
    float xDisplacement;

    [SerializeField] float maxX;
    [SerializeField] float minX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonUp(0))
        {
            isHeld = false;
        }

        if (isHeld)
        {
            //this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(mousePos.x, mousePos.y, 0), 0.01f);
            this.transform.position = new Vector3(mousePos.x - xDisplacement, this.transform.position.y, 0);
            Debug.Log("isHeld");
        }

        if (this.transform.position.x < minX) this.transform.position = new Vector3(minX, this.transform.position.y, 0);
        if (this.transform.position.x > maxX) this.transform.position = new Vector3(maxX, this.transform.position.y, 0);




    }

    private void OnMouseOver()
    {
        Debug.Log("MouseOver");
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

            xDisplacement = mousePos.x - this.transform.position.x;
            Debug.Log("IsClicked");
            isHeld = true;
        }
    }
}
