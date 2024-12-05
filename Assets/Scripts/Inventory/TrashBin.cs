using UnityEngine;
using UnityEngine.EventSystems;

public class TrashZone : MonoBehaviour, IDropHandler
{
    [SerializeField] private PetsInventory petsInventory;

    public void OnDrop(PointerEventData eventData)
    {
        DragSlot draggedSlot = eventData.pointerDrag.GetComponent<DragSlot>();
        if (draggedSlot != null)
        {
            draggedSlot.GetComponent<PetSlot>().TakePet();
            petsInventory.DeletePet();
            Destroy(draggedSlot.gameObject);
        }
    }
}
