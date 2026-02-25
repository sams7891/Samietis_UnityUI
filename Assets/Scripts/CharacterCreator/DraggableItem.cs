using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Allow dragging even over other UI elements
        canvasGroup.blocksRaycasts = false;
        rectTransform.SetAsLastSibling(); // Ensure it's on top while dragging
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Move the UI element freely
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Restore raycast blocking after drag
        canvasGroup.blocksRaycasts = true;
    }
}