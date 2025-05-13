using UnityEngine;

public class StickManager : MonoBehaviour
{

    public GameObject currentStick;
    public int posCount;
    [SerializeField] bool vaseScene;
    [SerializeField] Animator animator; 
    public LevelLoader levelLoader;

    bool level; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vaseScene)
        {
            if (posCount >= 9)
            {
                animator.speed = 1.0f;
                if (!level)
                {
                    levelLoader.bufferTime = 2f;
                    level = true; 
                }
            } else
            {
                animator.speed = 0.0f;
            }
        }
    }
}
