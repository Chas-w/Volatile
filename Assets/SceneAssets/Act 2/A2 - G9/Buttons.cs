using UnityEngine;

public class Buttons : MonoBehaviour
{
    public LoadedViewFinder viewFinder;
    [SerializeField] bool next;

    public bool triggerNext;
    public bool triggerBack; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        viewFinder.NextImage(triggerNext);
        viewFinder.GoBack(triggerBack);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Cursor")
        {
            if (next)
            {
                triggerNext = true;
            }
            if (!next)
            {
                triggerBack = true;
            }
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Cursor")
        {
            if (next)
            {
                triggerNext = true;
            }
            if (!next)
            {
                triggerBack = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Cursor")
        {
            if (next)
            {
                triggerNext = false;
            }
            if (!next)
            {
                triggerBack = false;
            }
        }
    }
}
