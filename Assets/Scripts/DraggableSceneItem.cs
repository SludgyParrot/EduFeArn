using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// A base class for scene items that can be dragged, dropped, and interactable through pointer events in Unity.
/// Implements interfaces to handle drag-and-drop functionality for objects in a scene.
/// </summary>
public abstract class DraggableSceneItem : SceneItem, IPointerDownHandler, IDragHandler, IPointerUpHandler, IDroppableItem
{
    public virtual void OnPointerDown(PointerEventData eventData)
    {

    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            Vector2 dragPosition = eventData.position;
            ItemTransform.position = dragPosition;
        }
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
       
    }

    public virtual void ShowItem()
        => ItemTransform.gameObject.SetActive(true);

    public virtual void HideItem()
        => ItemTransform.gameObject.SetActive(false);
}
