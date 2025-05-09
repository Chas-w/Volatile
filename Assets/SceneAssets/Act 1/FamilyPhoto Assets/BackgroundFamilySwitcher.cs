using System;
using NUnit.Framework;
using UnityEngine;

public class BackgroundFamilySwitcher : MonoBehaviour
{
    [SerializeField] Sprite[] familySprites;
    int currentFamily;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = familySprites[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) { 
            currentFamily++;
            if (currentFamily == familySprites.Length) currentFamily = 0;
            this.GetComponent<SpriteRenderer>().sprite = familySprites[currentFamily];
        }
    }
}
