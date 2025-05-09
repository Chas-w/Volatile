using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LighterBehavior : MonoBehaviour
{
    Animator anim;
    [SerializeField] Animator flameAnim;
    [SerializeField] GameObject cigarette;
    [SerializeField] AudioSource litCigSound; 
    [SerializeField] AudioClip lighterNoise;
    [SerializeField] AudioSource lighterSoundSource; 
    [SerializeField] Vector3 endPosition;

    bool isLit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            anim.SetTrigger("Lighting");
            lighterSoundSource.PlayOneShot(lighterNoise);
            StartCoroutine(StartFlame());
            isLit = true;
        }
        if (Input.GetMouseButtonUp(0)) {
            anim.SetTrigger("LetGo");
            flameAnim.SetTrigger("LetGo");
            isLit = false;
        }

        if (isLit && this.transform.position.x < endPosition.x + 0.1f && this.transform.position.x > endPosition.x - 0.1f
            && this.transform.position.y < endPosition.y + 0.1f && this.transform.position.y > endPosition.y - 0.1f) {
            LightCigarette();
        }

    }

    IEnumerator StartFlame()
    {
        yield return new WaitForSeconds(0.3f);
        //lighterSoundSource.PlayOneShot(lighterNoise);

        flameAnim.SetTrigger("Lighting");
    }

    void LightCigarette()
    {
        cigarette.GetComponent<Animator>().SetTrigger("Light");
        litCigSound.Play();
        Invoke("NextScene", 3);
    }

    void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
