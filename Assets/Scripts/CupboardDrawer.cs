using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class CupboardDrawer : SceneItem, IInteractable, IDropHandler
{
    [SerializeField]
    private Animator animator;

    public bool IsOpen {  get; private set; }

    public void Interact()
    {
        IsOpen = !IsOpen;
        OpenCloseDrawer(IsOpen);
    }

    private void OpenCloseDrawer(bool state)
    {
        if(animator == null)
        {
            throw new InvalidOperationException($"OpenCloseDrawer failed: The animator component: {nameof(animator)} is not assigned in the inspector panel");
        }

        animator.SetBool("IsOpen", state);
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerEnter != null)
        {
            IDroppableItem droppableItem = eventData.pointerDrag.transform.GetComponent<IDroppableItem>();

            if(droppableItem != null )
            {
                droppableItem.HideItem();
            }
        }
    }
}
