using UnityEngine;

public class LightbulbManager : MonoBehaviour
{

    [SerializeField] GameObject twisting;
    [SerializeField] GameObject lightbulb;
    [SerializeField] Sprite lightbulbOn;

    Vector3 lightbulbStartPosition;
    bool ding;
    AudioSource lightAudio; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lightAudio = GetComponent<AudioSource>();
        lightbulbStartPosition = lightbulb.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (lightbulb.transform.position.y > 1.86f)
        {
            lightbulb.transform.position = new Vector3(lightbulb.transform.position.x, lightbulbStartPosition.y - (twisting.GetComponent<TwistingBehavior>().totalRotation / 25), 10);
        }
        else
        {
            lightbulb.GetComponent<SpriteRenderer>().sprite = lightbulbOn;
            if (!ding)
            {
                lightAudio.Play();
                ding = true; 
            }
        }
    }
}
