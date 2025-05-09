using UnityEngine;

public class FilmManager : MonoBehaviour
{

    [SerializeField] GameObject[] christineFilmPieces;
    [SerializeField] GameObject[] larryFilm;
    [SerializeField] GameObject larryTray;
    [SerializeField] GameObject larryTrayFinalPosition;

    public GameObject currentFilmPiece;
    public bool trayIsFinal;

    bool isCheckingFilm;
    bool isMovingTray;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isCheckingFilm = true;

        for (int i = 0; i < christineFilmPieces.Length; i++)
        {
            christineFilmPieces[i].GetComponent<FilmPieceBehavior>().filmManager = this.gameObject;
        }
        for (int i = 0; i < larryFilm.Length; i++)
        {
            larryFilm[i].GetComponent<FilmPieceBehavior>().filmManager = this.gameObject;

        }
    }

    // Update is called once per frame
    void Update()
    {

        if (isCheckingFilm)
        {
            int numInFinal = 0;
            for (int i = 0; i < christineFilmPieces.Length; i++)
            {
                if (christineFilmPieces[i].GetComponent<FilmPieceBehavior>().isInFinalPosition) numInFinal++;
            }

            if (numInFinal >= christineFilmPieces.Length)
            {
                isCheckingFilm = false;
                isMovingTray = true;
            }
        }

        if (isMovingTray) {
            larryTray.transform.position = Vector3.Lerp(larryTray.transform.position, larryTrayFinalPosition.transform.position, 0.05f);
            if (larryTray.transform.position.x > larryTrayFinalPosition.transform.position.x - 0.1f) {
                for (int i = 0; i < larryFilm.Length; i++)
                {
                    larryFilm[i].GetComponent<FilmPieceBehavior>().isLarryFilm = false;
                    
                }

                isMovingTray = false;
                trayIsFinal = true;
            } 
        }


        
    }
}
