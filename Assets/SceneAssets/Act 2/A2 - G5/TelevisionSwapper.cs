using UnityEngine;

public class TelevisionSwapper : MonoBehaviour
{
    [SerializeField] Sprite[] channelSprites;
    int currentFamily;
    bool canContinue;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = channelSprites[0];
        canContinue = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canContinue)
        {
            currentFamily++;
            if (currentFamily == channelSprites.Length -1) canContinue = false;
            this.GetComponent<SpriteRenderer>().sprite = channelSprites[currentFamily];
        }
    }
}
