using UnityEngine;

public class CabbageHeadBehavior : MonoBehaviour
{
    [SerializeField] Sprite cabbageHead;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseEnter()
    {
        this.GetComponent<SpriteRenderer>().sprite = cabbageHead;
    }
}
