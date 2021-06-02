using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragNDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform myRect;
    private CanvasGroup myCanvasGroup;

    [SerializeField] private Canvas canvas;

    private Vector3 initPos;
    public bool droppedOnSpot;

    private Text answerText;

    private void Awake()
    {
        myRect = GetComponent<RectTransform>();
        myCanvasGroup = GetComponent<CanvasGroup>();
        answerText = GetComponentInChildren<Text>();
        initPos = transform.position;

    }

    public void SetAnswerText(string answerText)
    {
        this.answerText.text = answerText;

    }

    public string GetAnswerText()
    {
        return this.answerText.text;
    }

    private void Start()
    {
        initPos = transform.position;
        droppedOnSpot = false;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        // disable raycast block so that we can capture events from objects 'beneath' this on
        myCanvasGroup.blocksRaycasts = false;
        myCanvasGroup.alpha = 0.5f; // half fill
        this.droppedOnSpot = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // called every frame while draggin
        myRect.anchoredPosition += eventData.delta/canvas.scaleFactor; // current pixel scaling
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!droppedOnSpot)
        {
            transform.position = initPos;
        }
        // reenable raycast
        myCanvasGroup.blocksRaycasts = true;
        myCanvasGroup.alpha = 1f; // full fill
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //click
    }

    public void ResetPosition()
    {
        transform.position = initPos;
    }

}
