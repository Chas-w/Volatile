using UnityEngine;

public class BoatBehavior : MonoBehaviour
{

    [SerializeField] GameObject boat;
    [SerializeField] GameObject mouseTracker;

    [SerializeField] Transform startPosition;
    [SerializeField] Transform rotationOne;
    [SerializeField] Transform rotationTwo;

    [SerializeField] AudioSource slipSound; 

    [SerializeField] float downSpeed;

    bool isTurningRight;
    bool isSpinning;
    float spinTimer;

    Camera cam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isTurningRight = true;
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        
        this.transform.position = new Vector3(mousePos.x, this.transform.position.y, this.transform.position.z);
        this.transform.position += new Vector3(0, downSpeed * Time.deltaTime, 0);

        if(this.transform.position.x > 8f) this.transform.position = new Vector3(8f, this.transform.position.y, this.transform.position.z);
        if (this.transform.position.x < -8f) this.transform.position = new Vector3(-8f, this.transform.position.y, this.transform.position.z);

        if (isSpinning)
        {
            spinTimer += Time.deltaTime;
            this.transform.Rotate(new Vector3(0, 0, 400 * Time.deltaTime));

            if (spinTimer > 1)
            {
                isSpinning = false;
                spinTimer = 0;
                this.transform.rotation = Quaternion.identity;
                //isTurningRight = true;
            }
        } else
        {
            if (this.transform.rotation != Quaternion.identity) this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.identity, 0.005f);
        }
        
       

        /* else
        {
            if (isTurningRight)
            {
                this.transform.rotation = Quaternion.Lerp(this.transform.rotation, rotationOne.transform.rotation, 0.005f);
                if (this.transform.rotation == rotationOne.transform.rotation || this.transform.rotation.z > 0.2484) isTurningRight = false;
            }
            else
            {
                this.transform.rotation = Quaternion.Lerp(this.transform.rotation, rotationTwo.transform.rotation, 0.005f);
                if (this.transform.rotation == rotationTwo.transform.rotation || this.transform.rotation.z < -0.226) isTurningRight = true;
            }
        } */

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isSpinning = true;
        spinTimer = 0;
        slipSound.Play(); 
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        /*
        if(collision.gameObject.CompareTag("Rock"))
        {
            this.transform.position = startPosition.position;
            this.transform.rotation = startPosition.rotation;
        }
        */
    }




}
