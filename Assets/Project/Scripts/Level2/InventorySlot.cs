using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public DragAndDropManager ddm;
    public bool isExperiment;

    public void OnDrop(PointerEventData eventData)
    {
        if (ddm.IsDraggingValid == false) return;
        
        GameObject dropped = eventData.pointerDrag;
        DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();

        if (isExperiment)
        {
            if (dropped.gameObject == ddm.RelationsQueue[ddm.Level][0] && transform.gameObject == ddm.RelationsQueue[ddm.Level][1])
            {
                draggableItem.parentAfterDrag = transform;

                if (draggableItem != null)
                {
                    draggableItem.parentAfterDrag = transform;
                    draggableItem.transform.SetParent(transform);
                }
                ddm.Level++;
            }
        }
        else {
            draggableItem.parentAfterDrag = transform;

            if (draggableItem != null)
            {
                draggableItem.parentAfterDrag = transform;
                draggableItem.transform.SetParent(transform);
            }
            ddm.Level++;
        }

        
    }
}

