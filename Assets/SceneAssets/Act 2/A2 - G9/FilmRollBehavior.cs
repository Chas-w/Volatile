using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class FilmRollBehavior : MonoBehaviour
{
    Camera cam;
    bool isHeld;
    bool isInFinalPosition;
    float xDisplacement;
    float yDisplacement;

    public GameObject finalPosition;
    public GameObject displacementPosition;
    public GameObject manager;

    public List<Sprite> filmRoll;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
        isInFinalPosition = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isInFinalPosition)
        {
            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

            if (Input.GetMouseButtonUp(0))
            {
                isHeld = false;
                manager.GetComponent<ViewfinderBehavior>().currentRoll = null;
            }

            if (isHeld)
            {
                //this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(mousePos.x, mousePos.y, 0), 0.01f);
                this.transform.position = new Vector3(mousePos.x - xDisplacement, mousePos.y - yDisplacement, 0);
                Debug.Log("isHeld");
            }

            if (this.transform.position.x > 9) this.transform.position = new Vector3(6.8f, this.transform.position.y, 0);
            if (this.transform.position.x < -9) this.transform.position = new Vector3(-6.8f, this.transform.position.y, 0);

            if (this.transform.position.y < -5) this.transform.position = new Vector3(this.transform.position.x, -3.3f, 0);
            if (this.transform.position.y > 5) this.transform.position = new Vector3(this.transform.position.x, 3.3f, 0);


            if (this.transform.position.x > finalPosition.transform.position.x - 0.2f && this.transform.position.x < finalPosition.transform.position.x + 0.2f
                && this.transform.position.y > finalPosition.transform.position.y - 0.2f && this.transform.position.y < finalPosition.transform.position.y + 0.2f
                && !manager.GetComponent<ViewfinderBehavior>().isLooking && manager.GetComponent<ViewfinderBehavior>().currentRoll != null) {
                this.transform.position = new Vector3(finalPosition.transform.position.x, finalPosition.transform.position.y, 0);

                manager.GetComponent<ViewfinderBehavior>().StartFilm(filmRoll);
                this.transform.position = displacementPosition.transform.position;

                isInFinalPosition = false;
                isHeld = false;
            }
        }



    }

    private void OnMouseOver()
    {
        Debug.Log("MouseOver");
        if (Input.GetMouseButton(0) && manager.GetComponent<ViewfinderBehavior>().currentRoll == null || manager.GetComponent<ViewfinderBehavior>().currentRoll == this.gameObject)
        {
            Debug.Log("IsClicked");
            isHeld = true;

            manager.GetComponent<ViewfinderBehavior>().currentRoll = this.gameObject;

            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            xDisplacement = mousePos.x - this.transform.position.x;
            yDisplacement = mousePos.y - this.transform.position.y;
        }
    }

    private void OnMouseExit()
    {
        if (manager.GetComponent<ViewfinderBehavior>().currentRoll == this.gameObject) manager.GetComponent<ViewfinderBehavior>().currentRoll = null;
    }
}
