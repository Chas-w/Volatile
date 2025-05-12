using UnityEngine;

public class BlinkBlink : MonoBehaviour
{
    Animator animator;
    public Cracking cracks;
    bool ready = true; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();     
    }

    // Update is called once per frame
    void Update()
    {
        if (cracks.triggerEyes)
        {
            animator.speed = 1;
        }
        if (!cracks.triggerEyes)
        {
            animator.speed = 0; 
        }

    }
}
