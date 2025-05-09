using UnityEngine;

public class CameraBehavior : MonoBehaviour
{

    [SerializeField] GameObject MouseTracker;
    Vector3 mousePos;

    [Header("Sprites")]
    [SerializeField] Sprite smilingSprite;
    [SerializeField] Sprite frowningSprite;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = MouseTracker.transform.position;
        if (mousePos.x > 2f) mousePos = new Vector3(2f, mousePos.y, mousePos.z);
        if (mousePos.x < -8.5f) mousePos = new Vector3(-8.5f, mousePos.y, mousePos.z);
        this.transform.position = new Vector3(mousePos.x, 1.5f, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<SpriteRenderer>().sprite = smilingSprite;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.GetComponent<SpriteRenderer>().sprite = frowningSprite;
    }
}
