using UnityEngine;
using UnityEngine.EventSystems;

public class DragSlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Canvas canvas;                  // Canvas для корректного перемещения
    private RectTransform rectTransform;    // RectTransform этого слота
    private CanvasGroup canvasGroup;        // Для управления блокировкой событий
    private Transform originalParent;       // Оригинальный родитель
    private int originalSiblingIndex;       // Индекс в Layout Group

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
    }

    // Начало перетаскивания
    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent; // Запоминаем текущего родителя
        originalSiblingIndex = transform.GetSiblingIndex(); // Запоминаем индекс
        transform.SetParent(canvas.transform); // Переносим объект в Canvas
        canvasGroup.blocksRaycasts = false; // Отключаем блокировку событий
    }

    // Процесс перетаскивания
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    // Конец перетаскивания
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true; // Включаем блокировку событий

        // Проверяем, был ли слот "скинут" на подходящую цель
        if (transform.parent == canvas.transform)
        {
            // Если нет — возвращаем в оригинального родителя
            transform.SetParent(originalParent);
            transform.SetSiblingIndex(originalSiblingIndex); // Восстанавливаем позицию в Layout Group
        }
    }
}
