using UnityEngine;

public class CursorBehavior : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] bool grabDragScene; 
    [SerializeField] KeyCode[] joyStick; //from 0 - 3: up, down, left, right; 
    [SerializeField] KeyCode[] buttons; //from 0 - 2: left, right; 


    [Header("Movement")]
    [SerializeField] float mSpeed;

    [Header("Visual Clip Data")]
    [SerializeField] string[] sceneOption;
    [SerializeField] GameObject[] choiceObject; 

    Vector3 body;

    bool moveOn;
    bool dragReady;
    GameObject dragObject; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        JoyStickMovement();
        if (grabDragScene)
        {
            GrabDrag();
        }
        else
        {
            Chooser(); 
        }
    }

    private void JoyStickMovement()
    {
        if (Input.GetKey(joyStick[0])) //up
        {
            body.y += mSpeed * Time.deltaTime;
        }
        if (Input.GetKey(joyStick[1])) //down
        {
            body.y -= mSpeed * Time.deltaTime;
        }
        if (Input.GetKey(joyStick[2])) //left
        {
            body.x -= mSpeed * Time.deltaTime;
        }
        if (Input.GetKey(joyStick[3])) //right
        {
            body.x += mSpeed * Time.deltaTime;
        }

        transform.position = body;
    }

    private void GrabDrag()
    {
        if (dragReady && (Input.GetKey(buttons[1]))) // can be dragged and holding down a button
        {

        }
    }

    private void Chooser()
    {

    }



    // SceneManager.LoadScene(sceneOptions[1]); example of moving scenes
}
