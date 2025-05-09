using System.Collections;
using UnityEngine;

public class RulerBehavior : MonoBehaviour
{
    [Header("PositionOffsets")]
    [SerializeField] float xOffset; //-3
    [SerializeField] float yOffset; //+2

    SpriteRenderer spriteRenderer;
    AudioSource smackSound;
    Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
        smackSound = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Hits ruler down, offsets from the position of last key played - alternatively can be redone to use the last position of the hand
    public void RulerHit(Transform keyLocation)
    {
        StartCoroutine(HitRuler(keyLocation, 0.5f));
    }

    IEnumerator HitRuler(Transform keyLocation, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        smackSound.Play(); //plays the sound
        this.transform.position = new Vector3(keyLocation.position.x + xOffset, keyLocation.position.y + yOffset, 0);
        spriteRenderer.enabled = true; //shows the ruller

        StartCoroutine(RetractDelay(0.5f)); //retracts ruler
        animator.SetTrigger("Smack");

    }


    IEnumerator RetractDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        spriteRenderer.enabled = false;
    }
}
