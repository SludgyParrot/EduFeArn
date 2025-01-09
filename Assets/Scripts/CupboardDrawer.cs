using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class CupboardDrawer : SceneItem, IInteractable, IPointerEnterHandler, IPointerExitHandler, IDropHandler
{
    [SerializeField]
    private Animator animator;

    [Space(5)]
    [SerializeField]
    private RectTransform drawerItemsContainer;

    private RectTransform previousItemParent;

    public bool IsOpen
    {
        get
        {
            if (animator == null)
            {
                throw new InvalidOperationException($"OpenCloseDrawer failed: The animator component: {nameof(animator)} is not assigned in the inspector panel");
            }

            return animator.GetBool("IsOpen");
        }
    }

    private bool isOpen;

    public void Interact()
    {
        isOpen = !isOpen;
        OpenCloseDrawer(isOpen);
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
        if(!IsOpen)
        {
            return;
        }

        if(eventData.pointerEnter != null)
        {
            IDroppableItem droppableItem = eventData.pointerDrag.transform.GetComponent<IDroppableItem>();

            if(droppableItem != null )
            {
                droppableItem.HideItem();
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!IsOpen)
        {
            return;
        }

        if (eventData.pointerEnter != null)
        {
            IDroppableItem droppableItem = eventData.pointerDrag.transform.GetComponent<IDroppableItem>();

            if (droppableItem != null)
            {
                previousItemParent = eventData.pointerDrag.transform.parent as RectTransform;
                droppableItem.SetParent(drawerItemsContainer);
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!IsOpen)
        {
            return;
        }

        if (eventData.pointerEnter != null)
        {
            IDroppableItem droppableItem = eventData.pointerDrag.transform.GetComponent<IDroppableItem>();

            if (droppableItem != null)
            {
                if(previousItemParent == null)
                {
                    throw new InvalidOperationException("On item exit failed: Previous item parent cannot be null.");
                }

                droppableItem.SetParent(previousItemParent);
            }
        }
    }
}
