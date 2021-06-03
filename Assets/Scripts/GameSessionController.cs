using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSessionController : MonoBehaviour
{
    public GameObject gameUI;
    public Text scoreText;
    public GameOverController gameOver;
    private int curScore;
    private ExpressionController expressionController;

    private DragNDrop left;
    private DragNDrop mid;
    private DragNDrop right;

    private ItemDropZone dropZone;



    private float questionTimer;
    private float questionTime = 3f;

    public Image timerUI;

    private bool gameOn;


    private void Awake()
    {
        expressionController = gameUI.GetComponentInChildren<ExpressionController>();
        dropZone = gameUI.GetComponentInChildren<ItemDropZone>();
        Content.ShuffleDeck();
        foreach (DragNDrop obj in gameUI.GetComponentsInChildren<DragNDrop>())
        {
            if (obj.name == "Left") { left = obj;  }
            else if (obj.name == "Mid") { mid = obj; }
            else if (obj.name == "Right") { right = obj; }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SetNewQuestion(Content.GetCurrentIndex());
        curScore = 0;
        gameOn = true;
    }

    void SetNewQuestion(int index)
    {
        expressionController.SetExpression(Content.questions[index].expression);
        left.SetAnswerText(Content.questions[index].options[0]);
        mid.SetAnswerText(Content.questions[index].options[1]);
        right.SetAnswerText(Content.questions[index].options[2]);
        questionTimer = questionTime;
    }

    // Update is called once per frame
    void Update()
    {
        Timers();
        TimerUIControl();
        if (gameOn)
        {
            QuestionFlow();
        }
        else
        {
            gameUI.gameObject.SetActive(false);
            gameOver.ActivateGameOver();
            gameOver.SetFinalScore(curScore);
        }
    }

    private void QuestionFlow()
    {
        if (dropZone.GetCorrectlyAnswered())
        {
            AddScore();
            dropZone.ResetCorrectlyAnswered();
            Content.AdvanceIndex();
            SetNewQuestion(Content.GetCurrentIndex());
        }
    }

    void AddScore()
    {
        //curScore += (int)Mathf.Ceil(Time.deltaTime * 100);
        curScore += (int)Mathf.Ceil(questionTimer / questionTime * 100);
        scoreText.text = "Score: " + curScore.ToString();
    }

    /*
     * Timers 
     * **/
    void Timers()
    {
        if (questionTimer > 0)
        {
            questionTimer -= Time.deltaTime;
        }
        else
        {
            gameOn = false;
        }
    }

    /*
     * Controls the percentage of the visual timer bar 
     * **/
    void TimerUIControl()
    {
        timerUI.fillAmount = (questionTimer / questionTime);

    }
}
