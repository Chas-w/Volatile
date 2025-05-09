using UnityEngine;

public class ButtonManager : MonoBehaviour
{

    [SerializeField] GameObject[] buttons;
    [SerializeField] GameObject leftDoor;
    [SerializeField] Transform leftDoorFinal;
    [SerializeField] GameObject rightDoor;
    [SerializeField] Transform rightDoorFinal;


    bool isCheckingButtons;
    bool isMovingDoors;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isCheckingButtons = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCheckingButtons) {
            int buttonsPressed = 0;
            for (int i = 0; i < buttons.Length; i++) {
                if (buttons[i].GetComponent<ElevatorButtonBehavior>().isPressed) buttonsPressed++;
            }
            if (buttonsPressed >= buttons.Length)
            {
                isCheckingButtons = false;
                isMovingDoors = true;
            }
        }

        if(isMovingDoors)
        {
            leftDoor.transform.position = Vector3.Lerp(leftDoor.transform.position, leftDoorFinal.position, 0.01f);
            rightDoor.transform.position = Vector3.Lerp(rightDoor.transform.position, rightDoorFinal.position, 0.01f);

            if (leftDoor.transform.position.x < leftDoorFinal.position.x + 0.1f) isMovingDoors = false;
        }
    }
}
