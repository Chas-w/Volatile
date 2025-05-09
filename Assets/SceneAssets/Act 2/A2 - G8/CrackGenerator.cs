using UnityEngine;

public class CrackGenerator : MonoBehaviour
{
    [SerializeField] Sprite[] crackSprites;
    [SerializeField] GameObject background;
    [SerializeField] GameObject eye;
    [SerializeField] GameObject eye2;
    int currentCrack;
    bool canContinue;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = crackSprites[0];
        canContinue = true;
        eye.SetActive(false);
        eye2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canContinue)
        {
            currentCrack++;
            if (currentCrack == crackSprites.Length) {
                canContinue = false;
                //this.GetComponent<SpriteRenderer>().sprite = null;
                //background.SetActive(false);
                eye.SetActive(true);
                eye2.SetActive(true);
            }  else this.GetComponent<SpriteRenderer>().sprite = crackSprites[currentCrack];

        }
    }
}
