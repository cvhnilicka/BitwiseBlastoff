using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSessionController : MonoBehaviour
{
    public GameObject gameUI;
    private ExpressionController expressionController;

    private DragNDrop left;
    private DragNDrop mid;
    private DragNDrop right;

    private ItemDropZone dropZone;

    //public GameObjec

    private void Awake()
    {
        expressionController = gameUI.GetComponentInChildren<ExpressionController>();
        dropZone = gameUI.GetComponentInChildren<ItemDropZone>();
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
    }

    void SetNewQuestion(int index)
    {
        expressionController.SetExpression(Content.questions[index].expression);
        left.SetAnswerText(Content.questions[index].options[0]);
        mid.SetAnswerText(Content.questions[index].options[1]);
        right.SetAnswerText(Content.questions[index].options[2]);
    }

    // Update is called once per frame
    void Update()
    {
        if (dropZone.GetCorrectlyAnswered())
        {
            dropZone.ResetCorrectlyAnswered();
            Content.AdvanceIndex();
            SetNewQuestion(Content.GetCurrentIndex());
        }
    }
}
