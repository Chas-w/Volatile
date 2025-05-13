using UnityEngine;
//using static UnityEditor.PlayerSettings;
using UnityEngine.UIElements;
using UnityEngine.Video;

public class TelevisionSwapper : MonoBehaviour
{
    [SerializeField] VideoClip[] channelSprites;
    //[SerializeField] SpriteRenderer channels; 
    int currentFamily;
    public VideoPlayer tvScreen;
    //[SerializeField] VideoClip[] mp4s; 


    AudioSource audioSource; 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ChannelSwitch(); 
    }

    void ChannelSwitch()
    {
        for (int i = 0; i < channelSprites.Length; i++)
        {

            if (i == currentFamily)
            {
                // tvScreen.VideoClip = channelSprites[i];
                tvScreen.clip = channelSprites[i];
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.Play();

            if (currentFamily < channelSprites.Length - 1)
            {
                currentFamily++;

            } else
            {

                currentFamily = 0; 
            }

        }
    }
}
