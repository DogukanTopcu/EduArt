using UnityEngine;
using UnityEngine.EventSystems;

public class L9_InventorySlot : MonoBehaviour, IDropHandler
{
    public L9_DragDropManager ddm;
    public bool isExperiment;

    public void OnDrop(PointerEventData eventData)
    {
        if (ddm.IsDraggingValid == false) return;
        
        GameObject dropped = eventData.pointerDrag;
        L9_DraggableItem draggableItem = dropped.GetComponent<L9_DraggableItem>();

        if (isExperiment)
        {
            Debug.Log("Dropped: " + ddm.RelationsQueue[ddm.Level][0]);
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
