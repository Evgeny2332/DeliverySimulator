using UnityEngine;
using UnityEngine.EventSystems;

public class TouchController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Vector2 dragDelta { get; private set; }
    private Vector2 previousPosition;
    private bool isDragging = false;
    public float movementThreshold = 1.0f; // Порог для движения

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDragging = true;
        dragDelta = Vector2.zero;
        previousPosition = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 currentPosition = eventData.position;
        dragDelta = currentPosition - previousPosition;

        // Проверка порога движения: обновляем дельту только при реальном сдвиге
        if (dragDelta.magnitude > movementThreshold)
        {
            previousPosition = currentPosition;
        }
        else
        {
            dragDelta = Vector2.zero; // Обнуляем дельту, если движение меньше порога
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
        dragDelta = Vector2.zero;
    }

    public bool IsDragging()
    {
        return isDragging && dragDelta != Vector2.zero;
    }
}
