using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public GameObject finalScore;
    public GameObject quit;
    public GameObject start;
    public GameObject menu;

    // Start is called before the first frame update
    void Start()
    {

        start.SetActive(false);
        menu.SetActive(false);
        quit.SetActive(false);
        finalScore.SetActive(false);
    }

    public void ActivateGameOver()
    {
        start.SetActive(true);
        menu.SetActive(true);
        quit.SetActive(true);
        finalScore.SetActive(true);
    }

    public void SetFinalScore(float score)
    {
        finalScore.GetComponent<Text>().text = "Your Score: " + score.ToString();
    }
}
