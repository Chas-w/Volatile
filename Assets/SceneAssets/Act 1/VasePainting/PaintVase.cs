using UnityEngine;

public class PaintVase : MonoBehaviour
{
    /*
    [SerializeField] GameObject mouseTracker;
    [SerializeField] float hRadius;
    [SerializeField] float vRadius;
    [SerializeField] AudioSource paintBrush;
    [SerializeField] AudioSource ceramic;

    [SerializeField] float paintIntensity; 

    float alphaValue;
    Vector3 lastLocation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        paintIntensity *= 100; 
        alphaValue = 0f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        paintBrush.Pause();
        ceramic.Pause();
        if (mouseTracker.transform.position.x > this.transform.position.x - hRadius && mouseTracker.transform.position.x < this.transform.position.x + hRadius
            && mouseTracker.transform.position.y > this.transform.position.y - vRadius && mouseTracker.transform.position.y < this.transform.position.y + vRadius) {
            paintBrush.Play();
            ceramic.Play();
            if (lastLocation != mouseTracker.transform.position) {
                alphaValue += Mathf.Abs(Vector3.Magnitude(lastLocation - mouseTracker.transform.position)) / paintIntensity;
                if(alphaValue > 1) alphaValue = 1;
                lastLocation = mouseTracker.transform.position;
            }
        } 
        this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaValue);
    }
    */
    [SerializeField] float minDistance = .1f;
    [SerializeField] Brush brush; 

    LineRenderer line;
    Vector3 prevPos;

    AudioSource audioSource;
    bool play; 

    private void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 1; 
        prevPos = transform.position;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false; 
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (brush.stroke)
        {
            if (!play)
            {
                audioSource.Play();
                play = true; 
            }
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentPosition.z = 0;

            if (Vector3.Distance(currentPosition, prevPos) > minDistance)
            {
                if (prevPos == transform.position)
                {
                    line.SetPosition(0, currentPosition);
                }
                else
                {
                    line.positionCount++;
                    line.SetPosition(line.positionCount - 1, currentPosition);
                }


        
                prevPos = currentPosition;
            }
        }
        if (!brush.stroke)
        {
            play = false;
            audioSource.Pause();
        }
    }

}
