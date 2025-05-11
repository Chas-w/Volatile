using System;
using NUnit.Framework;
using UnityEngine;

public class BackgroundFamilySwitcher : MonoBehaviour
{
    [SerializeField] Sprite[] familySprites;
    int currentFamily;
    AudioSource audioCam; 



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioCam = GetComponent<AudioSource>();
        this.GetComponent<SpriteRenderer>().sprite = familySprites[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) { 
            currentFamily++;
            audioCam.Play();
            if (currentFamily == familySprites.Length) currentFamily = 0;
            this.GetComponent<SpriteRenderer>().sprite = familySprites[currentFamily];
        }
    }
}
