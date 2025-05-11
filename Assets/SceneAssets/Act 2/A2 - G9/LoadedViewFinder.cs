using UnityEngine;
using static Unity.VisualScripting.Metadata;

public class LoadedViewFinder : MonoBehaviour
{

    [Header("Audio")]
    [SerializeField] AudioSource buttAudio;
    [SerializeField] AudioClip backClip;
    [SerializeField] AudioClip nextClip; 

    [Header("Running the View")]
    public GameObject pov;
    public bool loaded;
    public Buttons next;
    public Buttons back;

    [Header("film data")]
    public GameObject[] filmCanister;
    public GameObject[] images;
    public bool[] filmChoice;
    public int assignedRoll;
    public CycleImages[] optionCycles; 

    [Header("Roll Positioning")]
    public GameObject[] roll;
    public GameObject[] rollResetPos; 

    int cycleNumb = 0; 

    float waitTime = 1;
    float waitTimer = 1;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        filmChoice[0] = false; filmChoice[1] = false; filmChoice[2] = false; 
    }

    // Update is called once per frame
    void Update()
    {
        InitialLoad();
        //NextImage(next.triggerNext);
    }

    void InitialLoad()
    {
        if (loaded)
        {
            waitTimer-= Time.deltaTime; 

            if (waitTimer < 0)
            {
                pov.SetActive(true);
                ResetFilmRolls();

            }
            //Debug.Log(whichfilmRoll);

            ChooseFilm(assignedRoll);
        }
    }

    void ChooseFilm(int whichfilmRoll)
    {

        if (whichfilmRoll == 1)
        {
            filmChoice[0] = true;
            filmChoice[1] = false;
            filmChoice[2] = false;

        }
        if (whichfilmRoll == 2)
        {
            filmChoice[0] = false;
            filmChoice[1] = true;
            filmChoice[2] = false;

        }
        if (whichfilmRoll == 3)
        {
            filmChoice[0] = false;
            filmChoice[1] = false;
            filmChoice[2] = true;

        }

        for (int i = 0; i < filmChoice.Length; i++)
        {
            filmCanister[i].SetActive(filmChoice[i]); 
            if (filmChoice[i] == true)
            {
                images = optionCycles[i].cycleable; 
            }
        }
    }

    public void NextImage(bool ready)
    {
        for (int i = 0;i < images.Length;i++)
        {
            if (i != cycleNumb)
            {
                images[i].SetActive(false);
            }
            if (i == cycleNumb)
            {
                images[i].SetActive(true);
            }
        }
        if (ready && Input.GetMouseButtonDown(0))
        {
            buttAudio.PlayOneShot(nextClip);
            if (cycleNumb < images.Length)
            {
                cycleNumb++;
            } 
            if (cycleNumb == images.Length)
            {
                cycleNumb = 0;
            }
        }
    }
    public void GoBack(bool ready)
    {
        if (ready && Input.GetMouseButtonDown(0))
        {
            cycleNumb = 0; 
            loaded = false;
            waitTimer = waitTime;
            buttAudio.PlayOneShot(backClip);
            pov.SetActive(false);
        }
    }

    void ResetFilmRolls()
    {
        for (int i = 0; i < roll.Length; i++)
        {
            roll[i].transform.position = rollResetPos[i].transform.position;
            //Debug.Log("reset");
        }
        
    }
}
