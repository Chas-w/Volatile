using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class ViewfinderBehavior : MonoBehaviour
{

    public GameObject currentRoll;
    public bool isLooking;
    int currentFilm;
    int currentRollNumber;
    List<Sprite> currentFilmRoll;

    [SerializeField] GameObject filmRollPlacement;
    [SerializeField] GameObject discardPlacement;
    [SerializeField] List<GameObject> filmRolls;
    [SerializeField] GameObject photo1;
    [SerializeField] GameObject photo2;
    [SerializeField] GameObject canvas;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canvas.SetActive(false);

        for (int i = 0; i < filmRolls.Count; i++)
        {
            filmRolls[i].GetComponent<FilmRollBehavior>().manager = this.gameObject;
            filmRolls[i].GetComponent<FilmRollBehavior>().finalPosition = filmRollPlacement;
            filmRolls[i].GetComponent<FilmRollBehavior>().displacementPosition = discardPlacement;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartFilm(List<Sprite> filmRoll)
    {
        currentFilm = 0;
        currentFilmRoll = filmRoll;

        photo1.GetComponent<Image>().sprite = currentFilmRoll[0];
        photo2.GetComponent<Image>().sprite = currentFilmRoll[0];

        canvas.SetActive(true);
        isLooking = true;
    }

    public void NextPicture()
    {
        currentFilm++;
        if (currentFilm >= currentFilmRoll.Count) currentFilm = 0;

        photo1.GetComponent<Image>().sprite = currentFilmRoll[currentFilm];
        photo2.GetComponent<Image>().sprite = currentFilmRoll[currentFilm];
    }

    public void Back()
    {
        currentRoll = null;

        isLooking = false;
        canvas.SetActive(false);
    }


}
