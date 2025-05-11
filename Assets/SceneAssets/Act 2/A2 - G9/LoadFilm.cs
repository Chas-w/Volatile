using UnityEngine;

public class LoadFilm : MonoBehaviour
{
    public Transform loadSpot;
    public BoxCollider2D triggerSpace;
    public LoadedViewFinder viewFinder;
    public int filmRollNumb;

    [SerializeField] AudioSource viewFinderAudio;
    bool triggerLoad;
    bool canGrab;


   // public CursorVisability hand; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        if (canGrab && Input.GetMouseButton(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
           // Debug.Log("grab");
        }

        LoadFilmBehavior(); 
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Cursor")
        {
            canGrab = true; 
        }

        if (collision.name == "Viewfinder")
        {
            triggerLoad = true; 
            viewFinderAudio.Play();
            Debug.Log("audioNow");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Cursor")
        {
            canGrab = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Cursor")
        {
            canGrab = false;
        }

        if (collision.name == "Viewfinder")
        {
            triggerLoad = false;
        }
    }

    void LoadFilmBehavior()
    {
        if (triggerLoad)
        {
            transform.position = Vector3.MoveTowards(transform.position, loadSpot.position, 1f);
            viewFinder.loaded = true;
            viewFinder.assignedRoll = filmRollNumb; 
        }
    }

}
