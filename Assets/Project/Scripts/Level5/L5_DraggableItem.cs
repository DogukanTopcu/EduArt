using UnityEngine;
using UnityEngine.EventSystems;

public class L5_DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [HideInInspector] public Transform parentAfterDrag;

    public UnityEngine.UI.Image image;
    private L5_DragDropManager ddm;
    private void Awake() {
        ddm = GameObject.Find("DragDropManager").GetComponent<L5_DragDropManager>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (ddm.IsDraggingValid) {
            parentAfterDrag = transform.parent;
            transform.SetParent(transform.root);
            transform.SetAsLastSibling();

            image.raycastTarget = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (ddm.IsDraggingValid)
        {
            transform.position = eventData.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (ddm.IsDraggingValid) {
            transform.SetParent(parentAfterDrag);
            image.raycastTarget = true;
        }
    }
}

