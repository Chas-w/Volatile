using System.Collections;
using UnityEngine;

public class HandBehavior : MonoBehaviour
{

    Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandPress()
    {
        animator.SetTrigger("Press");
        StartCoroutine(SmackDelay(0.4f)); 
    }
    IEnumerator SmackDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        animator.SetTrigger("Flinch");
    }
}
