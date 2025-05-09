using UnityEngine;
using UnityEngine.Rendering;

public class BucketBehavior : MonoBehaviour
{
    //Serialized
    [SerializeField] GameObject MouseTracker;

    //Public
    public int rainCount;
    public bool isWalking;

    //Private
    Vector3 mousePos;
    Animator animator;
    float lastMouseX;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastMouseX = this.transform.position.x;
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = MouseTracker.transform.position;
        if (mousePos.x > 8.5f) mousePos = new Vector3(8.5f, mousePos.y, mousePos.z);
        if (mousePos.x < -8.5f) mousePos = new Vector3(-8.5f, mousePos.y, mousePos.z);
        this.transform.position = new Vector3(mousePos.x, -3f, 0);

        if (mousePos.x != lastMouseX) isWalking = true; else isWalking = false;

        animator.SetBool("isWalking", isWalking);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Rain"))
        {
            rainCount++;
            Destroy(collision.gameObject);
        }
    }
}
