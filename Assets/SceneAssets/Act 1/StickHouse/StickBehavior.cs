using UnityEngine;

public class StickBehavior : MonoBehaviour
{

    Camera cam;
    bool isHeld;
    bool isInFinalPosition;
    float xDisplacement;
    float yDisplacement;

    [SerializeField] GameObject finalPosition;
    [SerializeField] GameObject manager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
        isInFinalPosition = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isInFinalPosition) {
            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

            if (Input.GetMouseButtonUp(0))
            {
                isHeld = false;
                manager.GetComponent<StickManager>().currentStick = null;
            }

            if (isHeld) {
                //this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(mousePos.x, mousePos.y, 0), 0.01f);
                this.transform.position = new Vector3(mousePos.x - xDisplacement, mousePos.y - yDisplacement, 0);
                Debug.Log("isHeld");
            }

            if(this.transform.position.x > 9) this.transform.position = new Vector3(6.8f, this.transform.position.y, 0);
            if (this.transform.position.x < -9) this.transform.position = new Vector3(-6.8f, this.transform.position.y, 0);

            if (this.transform.position.y < -5) this.transform.position = new Vector3(this.transform.position.x, -3.3f, 0);
            if (this.transform.position.y > 5) this.transform.position = new Vector3(this.transform.position.x, 3.3f, 0);


            if (this.transform.position.x > finalPosition.transform.position.x - 0.2f && this.transform.position.x < finalPosition.transform.position.x + 0.2f
                && this.transform.position.y > finalPosition.transform.position.y - 0.2f && this.transform.position.y < finalPosition.transform.position.y + 0.2f)
            {
                this.transform.position = new Vector3(finalPosition.transform.position.x, finalPosition.transform.position.y, 0);

                manager.GetComponent<StickManager>().currentStick = null;

                isInFinalPosition = true;
                isHeld = false;
            }
        }

        

    }

    private void OnMouseOver()
    {
        Debug.Log("MouseOver");
        if (Input.GetMouseButton(0) && manager.GetComponent<StickManager>().currentStick == null || manager.GetComponent<StickManager>().currentStick == this.gameObject) {
            Debug.Log("IsClicked");
            isHeld = true;

            manager.GetComponent<StickManager>().currentStick = this.gameObject;

            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            xDisplacement = mousePos.x - this.transform.position.x;
            yDisplacement = mousePos.y - this.transform.position.y;
        }
    }

    private void OnMouseExit()
    {
        if (manager.GetComponent<StickManager>().currentStick == this.gameObject) manager.GetComponent<StickManager>().currentStick = null;
    }
}
