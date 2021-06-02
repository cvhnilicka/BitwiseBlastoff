using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDropZone : MonoBehaviour, IDropHandler
{
    private GameObject answerDropped;

    public Text expressionText;

    bool correctlyAnswered = false;



    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
            eventData.pointerDrag.GetComponent<DragNDrop>().droppedOnSpot = true;
            answerDropped = eventData.pointerDrag.gameObject;
            CheckFuelAnswer();
        }
    }


    void CheckFuelAnswer()
    {
        // HARDCODED FOR NOW FOR TESTING
        if (answerDropped.GetComponent<DragNDrop>().GetAnswerText() == Content.questions[Content.GetCurrentIndex()].answer)
        {
            correctlyAnswered = true;
        }
        ClearDroppedAnswer();

    }

    void ClearDroppedAnswer()
    {
        answerDropped.GetComponent<DragNDrop>().ResetPosition();
        answerDropped = null;


    }

    public bool GetCorrectlyAnswered()
    {
        return this.correctlyAnswered;
    }

    public void ResetCorrectlyAnswered()
    {
        this.correctlyAnswered = false;
    }


}
