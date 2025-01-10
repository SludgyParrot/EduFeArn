using System;
using UnityEngine;
using UnityEngine.EventSystems;

using static GlobalEnums;

public class CupboardDrawer : SceneItem, IPointerEnterHandler, IPointerExitHandler, IDropHandler
{
    [SerializeField]
    private Animator animator;

    [Space(5)]
    [SerializeField]
    private AudioClip drawerOpenSoundClip, 
                      drawerCloseSoundClip,
                      drawerItemDropSoundClip;

    [Space(5)]
    [SerializeField]
    private RectTransform drawerItemsContainer;

    private RectTransform previousItemParent;

    public bool IsOpen
    {
        get => animator.GetBool("IsOpen");
    }

    private void OnEnable()
    {
        DelegateEventsManager.Instance.RegisterEvents((OpenDrawer, DelegateEventType.OnRoundStartedEvent), (CloseDrawer, DelegateEventType.OnRoundCompletedEvent));
    }

    private void OnDisable()
    {
        DelegateEventsManager.Instance.UnregisterEvents((OpenDrawer, DelegateEventType.OnRoundStartedEvent), (CloseDrawer, DelegateEventType.OnRoundCompletedEvent));
    }

    private void Start()
    {
        if (animator == null)
        {
            throw new InvalidOperationException($"OpenCloseDrawer failed: The animator component: {nameof(animator)} is not assigned in the inspector panel");
        }
    }

    private void OpenDrawer()
    {
        animator.SetBool("IsOpen", true);
        SoundManager.Instance.PlayClip(drawerOpenSoundClip);
    }

    private void CloseDrawer()
    {
        animator.SetBool("IsOpen", false);
        SoundManager.Instance.PlayClip(drawerCloseSoundClip);
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(!IsOpen)
        {
            return;
        }

        if(eventData.pointerEnter != null)
        {
            Sock droppableItem = eventData?.pointerDrag?.transform?.GetComponent<IDroppableItem>() as Sock;

            if(droppableItem != null )
            {
                droppableItem.HideItem();

                AssessmentStateManager.Instance.CheckResults(droppableItem.SockColor, success => 
                {
                    if(success)
                    {
                        SoundManager.Instance.PlayClip(drawerItemDropSoundClip);
                    }
                });
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
            IDroppableItem droppableItem = eventData?.pointerDrag?.transform?.GetComponent<IDroppableItem>();

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
            IDroppableItem droppableItem = eventData?.pointerDrag?.transform?.GetComponent<IDroppableItem>();

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
