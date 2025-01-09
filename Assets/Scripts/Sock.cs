using UnityEngine;
using UnityEngine.EventSystems;

using static GlobalEnums;

public class Sock : DraggableSceneItem
{
    [field: SerializeField]
    public ItemColor SockColor {  get; private set; }

    public override void OnDrag(PointerEventData eventData)
        => base.OnDrag(eventData);
}
