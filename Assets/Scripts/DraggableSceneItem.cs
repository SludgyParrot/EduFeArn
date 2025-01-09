using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// A base class for scene items that can be dragged, dropped, and interactable through pointer events in Unity.
/// Implements interfaces to handle drag-and-drop functionality for objects in a scene.
/// </summary>
public abstract class DraggableSceneItem : SceneItem, IPointerDownHandler, IPointerUpHandler, IDragHandler, IDropHandler
{
    public virtual void OnDrag(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            Vector2 dragPosition = eventData.position;
            ItemTransform.position = dragPosition;
        }
    }

    public virtual void OnDrop(PointerEventData eventData)
    {
        

        Debug.Log("==> On Drop");
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("==> On Pointer Down");

     
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("==> On Pointer Up");
    }
}
