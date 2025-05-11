using UnityEngine;
using static UnityEditor.PlayerSettings;
using UnityEngine.UIElements;

public class TelevisionSwapper : MonoBehaviour
{
    [SerializeField] Sprite[] channelSprites;
    [SerializeField] SpriteRenderer channels; 
    int currentFamily;


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
                channels.sprite = channelSprites[i];
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
