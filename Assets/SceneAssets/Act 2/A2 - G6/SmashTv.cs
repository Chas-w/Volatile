using UnityEngine;

public class SmashTv : MonoBehaviour
{
    [SerializeField] CameraShake cam;
    [SerializeField] Sprite[] TVs; 
    SpriteRenderer TVRenderer;

    AudioSource TVAudSource;

    int cycleNumb = 0; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TVRenderer = GetComponent<SpriteRenderer>();
        TVAudSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Smash();    
    }
    void Smash()
    {

        for (int i = 0; i < TVs.Length; i++)
        {

            if (i == cycleNumb)
            {
                TVRenderer.sprite = TVs[i];
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (cycleNumb < TVs.Length - 1)
            {
                TVAudSource.Play();
                cycleNumb++;
                cam.triggerShake = true;

            }

        }


    }
}
