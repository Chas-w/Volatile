using UnityEngine;

public class CharacterConverter : MonoBehaviour
{
    [Header("Sprites")]
    [SerializeField] Sprite shanghaiAncient;
    [SerializeField] Sprite shanghaiModern;
    [SerializeField] Sprite traditional;
    [SerializeField] Sprite simplified;

    [Header("GameObjects")]
    [SerializeField] GameObject backgroundImage;

    //private variables
    bool isModern;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isModern = false;
    }

    private void OnMouseEnter()
    {
        Convert();
    }

    private void Convert()
    {
        if(this.GetComponent<SpriteRenderer>().sprite == traditional)
        {
            this.GetComponent<SpriteRenderer>().sprite = simplified;
            backgroundImage.GetComponent<SpriteRenderer>().sprite = shanghaiModern;
        } else
        {
            this.GetComponent<SpriteRenderer>().sprite = traditional;
            backgroundImage.GetComponent<SpriteRenderer>().sprite = shanghaiAncient;
        }
    }
}
