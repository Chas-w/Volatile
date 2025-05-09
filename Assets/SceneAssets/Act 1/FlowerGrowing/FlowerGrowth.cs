using UnityEngine;

public class FlowerGrowth : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Animator flowerAnim;
    public GameObject wateringCan;

    bool canWater; 
    void Start()
    {
      flowerAnim = GetComponent<Animator>();
      Cursor.visible = false;
      Cursor.lockState = CursorLockMode.Confined;

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(flowerAnim.name);
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        wateringCan.transform.position = mousePosition;

        if (/*Input.GetMouseButton(0) && */ canWater && flowerAnim != null)
        {
            // flowerAnim.speed = 1f;
            flowerAnim.speed = 1f;
        } else
        {
            //flowerAnim.speed = 0f;
            flowerAnim.speed = 0f;
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == wateringCan.name)
        {
            canWater = true; 
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        {
            if (collision.gameObject.name == wateringCan.name)
            {
                canWater = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        {
            if (collision.gameObject.name == wateringCan.name)
            {
                canWater = false;
            }
        }
    }

}
