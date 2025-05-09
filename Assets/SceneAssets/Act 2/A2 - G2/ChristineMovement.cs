using UnityEngine;

public class ChristineMovement : MonoBehaviour
{

    [Header("GameObjects")]
    [SerializeField] GameObject mouseTracker;

    [Header("Changeable Variables")]
    [SerializeField] float speed;

    //public variables
    public bool isStopped;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isStopped) {
            if (mouseTracker.transform.position.x > this.transform.position.x)
            {
                this.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            }
            else if (mouseTracker.transform.position.x < this.transform.position.x)
            {
                this.transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
            }
        }
        
    }
}
