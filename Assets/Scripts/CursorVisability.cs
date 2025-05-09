using UnityEngine;

public class CursorVisability : MonoBehaviour
{
    public GameObject cursorEmpty;
    public GameObject cursorGrab; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            cursorEmpty.SetActive(false);
            cursorGrab.SetActive(true) ;

        }
        else
        {
            cursorGrab.SetActive(false);
            cursorEmpty.SetActive(true);

        }

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursorGrab.transform.position = mousePosition;
        cursorEmpty.transform.position = mousePosition;


    }
}
