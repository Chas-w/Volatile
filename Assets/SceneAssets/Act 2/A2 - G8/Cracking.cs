using UnityEngine;

public class Cracking : MonoBehaviour
{
    [SerializeField] GameObject[] cracks;
    public CameraShake cam;
    AudioSource crackAudio; 

    int cycleNumb = 0;
    public bool triggerEyes; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        crackAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        CrackSeal();
        
    }

    void CrackSeal()
    {

        for (int i = 0; i < cracks.Length; i++)
        {
            if (i != cycleNumb)
            {
                cracks[i].SetActive(false);
            }
            if (i == cycleNumb)
            {
                cracks[i].SetActive(true);
            }
        }
        if (Input.GetMouseButtonDown(0) && !triggerEyes)
        {
            if (cycleNumb < cracks.Length -1)
            {
                crackAudio.Play();
                cycleNumb++;
                cam.triggerShake = true;

            }
  
        }
        if (cycleNumb == cracks.Length -1)
        {
            // cam.triggerShake = true;

            triggerEyes = true;
            Debug.Log(triggerEyes);

        }

    }

}
