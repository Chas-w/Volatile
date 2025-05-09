using UnityEngine;

public class KeyBehavior : MonoBehaviour
{
    [Header("Sprites")]
    [SerializeField] Sprite UpSprite;
    [SerializeField] Sprite DownSprite;


    //private
    GameObject ruler;
    GameObject hand;
    AudioSource keyNote;
    float downTimer;
    bool isDown;

 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ruler = GameObject.FindGameObjectWithTag("Ruler");
        hand = GameObject.FindGameObjectWithTag("Hand");
        keyNote = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if(isDown)
        {
            downTimer += Time.deltaTime;
            if (downTimer > 0.5f)
            {
                isDown = false;
                downTimer = 0;
                this.GetComponent<SpriteRenderer>().sprite = UpSprite;
            }
        }
    }
    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0) && !isDown)
        {
            ruler.GetComponent<RulerBehavior>().RulerHit(hand.transform); //hits down ruler
            hand.GetComponent<HandBehavior>().HandPress();

            keyNote.Play(); //will play note once added
            PressKey();
        }
    }

    void PressKey()
    {
        isDown = true;
        this.GetComponent<SpriteRenderer>().sprite = DownSprite;
    }
}
