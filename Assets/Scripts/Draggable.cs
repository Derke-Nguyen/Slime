using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform originalParent = null;

    protected bool IsHeld = false;

    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        IsHeld = true;
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        if(IsHeld)
            this.transform.position = eventData.position;
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(originalParent);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        IsHeld = false;
    }

    public virtual void DroppedIn(Transform newParent)
    {
        originalParent = newParent;
        this.transform.position = Vector3.zero;
    }
}
