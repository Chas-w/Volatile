using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [Header("Timers")]
    [SerializeField] int timeAwayTimer; //can be used later to go back to menu if no one is interacting; 
    [SerializeField] float bufferTime;

    [Header("Scene Data")]
    [SerializeField] bool gameScene;
    public bool miniGameDone; //not sure we'll need this but I'm giving us this option
    public AudioSource interviewAudio;


    bool inMenu;


    private void Awake()
    {
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ReturnToMenu();
        InMenuScene();
        if (gameScene)
        {
            GameSceneManager();
        } else
        {
            CutSceneManager();

        }

    }

    public void GameSceneManager()
    {
        if (!interviewAudio.isPlaying) //once the interview audio is done playing, trigger a buffer period (in case the audio clip is shorter than gameplay)
        {
            if (bufferTime >= 0)
            {
                bufferTime-= Time.deltaTime;
                if (bufferTime < 0)
                {
                    LoadNextScene();
                }
            }
        }

    }

    public void CutSceneManager()
    {
        if (!interviewAudio.isPlaying) //load the next scene if there is no interview audio playing; 
        {
            LoadNextScene(); 
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReturnToMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MenuScene");
        }
    }

    public void InMenuScene()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MenuScene"))
        {
            inMenu = true;
        } else { inMenu = false; }

        if (inMenu && Input.GetMouseButtonDown(0))
        {
            LoadNextScene();
        }
    }


}
