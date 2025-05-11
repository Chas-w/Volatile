using UnityEngine;

public class Parallax : MonoBehaviour
{

  //  [Header("GameObjects")]
    //[SerializeField] GameObject mouseTracker;

    [Header("Changeable Variables")]
    [SerializeField] float speed;

    //public variables
    public ChristineMovement christineMovement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!christineMovement.isStopped && Input.GetMouseButton(0))
        {
          
            this.transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
            
        }
    }
}
