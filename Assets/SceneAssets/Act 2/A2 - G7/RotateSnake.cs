using UnityEngine;

public class RotateSnake : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    [SerializeField] AudioSource audioSource;
    bool play; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) {
            this.transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime));
            if (play)
            {
                audioSource.Play();
                play = false; 
            }
        } else
        {
            audioSource.Pause();
            play = true;
        }
    }


}
