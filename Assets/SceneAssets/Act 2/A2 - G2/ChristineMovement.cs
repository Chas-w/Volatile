using UnityEngine;

public class ChristineMovement : MonoBehaviour
{

   // [Header("GameObjects")]
   // [SerializeField] GameObject mouseTracker;

    [Header("Changeable Variables")]
    [SerializeField] float speed;
    Animator animator;

    float inputTimer = 3; 
    //public variables
    public bool isStopped;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        inputTimer-= Time.deltaTime;

        if (Input.GetMouseButton(0) || inputTimer <= 0 ) {
            //if (mouseTracker.transform.position.x > this.transform.position.x)
           // {
                this.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
           // }
            //else if (mouseTracker.transform.position.x < this.transform.position.x)
           // {
                //this.transform.position += new Vector3(0, 0, 0);
           // }
        }

        if (Input.GetMouseButton(0))
        {
            inputTimer = 1.5f; 
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Respawn")
        {
            animator.SetBool("Friends", true);
        }
    }
}
