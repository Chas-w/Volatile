using UnityEngine;

public class ElevatorButtonBehavior : MonoBehaviour
{

    SpriteRenderer sr;

    public bool isPressed;

    [SerializeField] Color startingColor;
    [SerializeField] Color hoverColor;
    [SerializeField] Color pressedColor;

    //Once sprites are added, a sprite array will probably have to be created

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnMouseEnter()
    {
        if(!isPressed) sr.color = hoverColor;
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && !isPressed) { 
            isPressed = true;
            sr.color = pressedColor;
        }
    }

    private void OnMouseExit()
    {
        if (!isPressed) sr.color = startingColor;
    }
}
