using UnityEngine;

public class RainManager : MonoBehaviour
{
    [SerializeField] GameObject rainPrefab;
    [SerializeField] float waitTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("SpawnRain", waitTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnRain()
    {
        float randomX = Random.Range(-8.5f, 8.5f);
        GameObject.Instantiate(rainPrefab, new Vector3(randomX, 5, 5), Quaternion.identity);

        Invoke("SpawnRain", waitTime);
    }
}
