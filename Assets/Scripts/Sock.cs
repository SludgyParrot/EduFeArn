using UnityEngine;
using UnityEngine.EventSystems;

using static GlobalEnums;

public class Sock : DraggableSceneItem
{
    [field: SerializeField]
    public ItemColor SockColor {  get; private set; }

    public override void OnDrag(PointerEventData eventData)
    {
       base.OnDrag(eventData);
    }

    public override void OnDrop(PointerEventData eventData)
    {
        base.OnDrop(eventData);
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
    }
}
