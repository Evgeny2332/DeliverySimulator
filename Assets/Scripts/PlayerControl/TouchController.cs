using UnityEngine;
using UnityEngine.EventSystems;

public class TouchController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Vector2 dragDelta { get; private set; }
    private Vector2 previousPosition;
    private bool isDragging = false;
    public float movementThreshold = 1.0f; // ����� ��� ��������

    private static int activePointerId = -1; // ������������� ��������� ������� (-1, ���� ��� ��������� �������)

    public void OnBeginDrag(PointerEventData eventData)
    {
        // ���� ��� ���� �������� �������, ���������� ���
        if (activePointerId != -1 && activePointerId != eventData.pointerId)
        {
            return;
        }

        // ������������� ������� ������� ��� ��������
        activePointerId = eventData.pointerId;
        isDragging = true;
        dragDelta = Vector2.zero;
        previousPosition = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // ���������, ��� �������������� ������ �������� �������
        if (eventData.pointerId != activePointerId)
        {
            return;
        }

        Vector2 currentPosition = eventData.position;
        dragDelta = currentPosition - previousPosition;

        // ��������� ����� ��������
        if (dragDelta.magnitude > movementThreshold)
        {
            previousPosition = currentPosition;
        }
        else
        {
            dragDelta = Vector2.zero; // �������� ������, ���� �������� ������ ������
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // ���������, ��� ��������� �������� �������
        if (eventData.pointerId != activePointerId)
        {
            return;
        }

        // ���������� ���������
        activePointerId = -1;
        isDragging = false;
        dragDelta = Vector2.zero;
    }

    public bool IsDragging()
    {
        return isDragging && dragDelta != Vector2.zero;
    }
}
