using UnityEngine;

public class DoorBehavior : MonoBehaviour
{

    bool hasStopped;
    GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hasStopped && Input.GetMouseButton(0)) player.GetComponent<ChristineMovement>().isStopped = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasStopped) {
            player = collision.gameObject;
            collision.gameObject.GetComponent<ChristineMovement>().isStopped = true;
            hasStopped = true;


        }
        
    }
}
