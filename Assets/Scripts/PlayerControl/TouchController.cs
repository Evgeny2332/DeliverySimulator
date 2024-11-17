using UnityEngine;
using UnityEngine.EventSystems;

public class TouchController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Vector2 dragDelta { get; private set; }
    private Vector2 previousPosition;
    private bool isDragging = false;
    public float movementThreshold = 1.0f; // Порог для движения

    private static int activePointerId = -1; // Идентификатор активного касания (-1, если нет активного касания)

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Если уже есть активное касание, игнорируем это
        if (activePointerId != -1 && activePointerId != eventData.pointerId)
        {
            return;
        }

        // Устанавливаем текущее касание как активное
        activePointerId = eventData.pointerId;
        isDragging = true;
        dragDelta = Vector2.zero;
        previousPosition = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Проверяем, что обрабатывается только активное касание
        if (eventData.pointerId != activePointerId)
        {
            return;
        }

        Vector2 currentPosition = eventData.position;
        dragDelta = currentPosition - previousPosition;

        // Проверяем порог движения
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
        // Проверяем, что завершает активное касание
        if (eventData.pointerId != activePointerId)
        {
            return;
        }

        // Сбрасываем состояние
        activePointerId = -1;
        isDragging = false;
        dragDelta = Vector2.zero;
    }

    public bool IsDragging()
    {
        return isDragging && dragDelta != Vector2.zero;
    }
}
