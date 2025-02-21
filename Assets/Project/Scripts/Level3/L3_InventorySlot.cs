using UnityEngine;
using UnityEngine.EventSystems;

public class L3_InventorySlot : MonoBehaviour, IDropHandler
{
    public L3_DragDropManager ddm;
    public bool isExperiment;

    public void OnDrop(PointerEventData eventData)
    {
        if (ddm.IsDraggingValid == false) return;
        
        GameObject dropped = eventData.pointerDrag;
        L3_DraggableItem draggableItem = dropped.GetComponent<L3_DraggableItem>();

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
