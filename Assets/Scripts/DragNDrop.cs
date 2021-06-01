using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragNDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform myRect;
    private CanvasGroup myCanvasGroup;

    [SerializeField] private Canvas canvas;

    private void Awake()
    {
        myRect = GetComponent<RectTransform>();
        myCanvasGroup = GetComponent<CanvasGroup>();

    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        myCanvasGroup.blocksRaycasts = false;
        myCanvasGroup.alpha = 0.5f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // called every frame while draggin
        Debug.Log("OnDrag");
        myRect.anchoredPosition += eventData.delta/canvas.scaleFactor; // current pixel scaling
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        myCanvasGroup.blocksRaycasts = true;
        myCanvasGroup.alpha = 1f;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

}
