using UnityEngine;
using UnityEngine.Rendering;

public class FilmBreakBehavior : MonoBehaviour
{
    Camera cam;
    bool isHeld;

    float xDisplacement;
    float yDisplacement;

    [SerializeField] GameObject finalPosition;
    [SerializeField] bool useX;
    [SerializeField] bool useY;

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
                if(useY) this.transform.position = new Vector3(this.transform.position.x, mousePos.y - yDisplacement, 0);
                if (useX) this.transform.position = new Vector3(mousePos.x - xDisplacement, this.transform.position.y, 0);
                Debug.Log("isHeld");
            }
            /*

            if (this.transform.position.x > 9) this.transform.position = new Vector3(6.8f, this.transform.position.y, 0);
            if (this.transform.position.x < -9) this.transform.position = new Vector3(-6.8f, this.transform.position.y, 0);

            if (this.transform.position.y < -5) this.transform.position = new Vector3(this.transform.position.x, -3.3f, 0);
            if (this.transform.position.y > 5) this.transform.position = new Vector3(this.transform.position.x, 3.3f, 0);
            */


            



    }

    private void OnMouseOver()
    {
        Debug.Log("MouseOver");
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

            xDisplacement = mousePos.x - this.transform.position.x;
            yDisplacement = mousePos.y - this.transform.position.y;
            Debug.Log("IsClicked");
            isHeld = true;
        }
    }
}
