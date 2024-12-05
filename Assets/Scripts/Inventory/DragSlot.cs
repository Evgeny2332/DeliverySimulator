using UnityEngine;
using UnityEngine.EventSystems;

public class DragSlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Canvas canvas;                  // Canvas ��� ����������� �����������
    private RectTransform rectTransform;    // RectTransform ����� �����
    private CanvasGroup canvasGroup;        // ��� ���������� ����������� �������
    private Transform originalParent;       // ������������ ��������
    private int originalSiblingIndex;       // ������ � Layout Group

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
    }

    // ������ ��������������
    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent; // ���������� �������� ��������
        originalSiblingIndex = transform.GetSiblingIndex(); // ���������� ������
        transform.SetParent(canvas.transform); // ��������� ������ � Canvas
        canvasGroup.blocksRaycasts = false; // ��������� ���������� �������
    }

    // ������� ��������������
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    // ����� ��������������
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true; // �������� ���������� �������

        // ���������, ��� �� ���� "������" �� ���������� ����
        if (transform.parent == canvas.transform)
        {
            // ���� ��� � ���������� � ������������� ��������
            transform.SetParent(originalParent);
            transform.SetSiblingIndex(originalSiblingIndex); // ��������������� ������� � Layout Group
        }
    }
}
