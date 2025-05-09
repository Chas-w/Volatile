using UnityEngine;

public class MouseTracker : MonoBehaviour
{

    Camera cam;
    public Vector3 mousePos;

    /*
    [Header("Parameters")]
    [SerializeField] bool canUseY;
    [SerializeField] bool canUseX;
    [SerializeField] float maxX;
    [SerializeField] float minX;
    [SerializeField] float maxY;
    [SerializeField] float minY;
    [SerializeField] float staticX;
    [SerializeField] float staticY;
    */

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        
        /*
        float mouseX = mousePos.x;
        float mouseY = mousePos.y;

        if (canUseY && canUseX)
        {
            if (mouseX > maxX)
            {
                mouseX = maxX;
            }
            else if (mouseX < minX) { 
                mouseX = minX;
            }

            if (mouseY > maxY)
            {
                mouseY = maxY;
            }
            else if (mouseY < minY) { 
                mouseY = minY;
            }
        } else if (canUseY && !canUseX)
        {
            if (mouseY > maxY)
            {
                mouseY = maxY;
            }
            else if (mouseY < minY)
            {
                mouseY = minY;
            }

            mouseX = staticX;

        } else if (canUseX && !canUseY)
        {
            if (mouseX > maxX)
            {
                mouseX = maxX;
            }
            else if (mouseX < minX)
            {
                mouseX = minX;
            }

            mouseY = staticY;
        } else
        {
            mouseX = staticX;
            mouseY = staticY;
        }
        */

        mousePos = new Vector3(mousePos.x, mousePos.y, 0);
        this.transform.position = mousePos;
    }
}
