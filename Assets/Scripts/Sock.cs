using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

using static GlobalEnums;

public class Sock : DraggableSceneItem
{
    [field: SerializeField]
    public ItemColor SockColor {  get; private set; }

    private Vector2 defaultPosition;
    private Transform defaultParent;

    public Image SockImageDisplayer
    {
        get
        {
            if(sockImageDisplayer == null)
            {
                sockImageDisplayer = GetComponent<Image>();
            }

            return sockImageDisplayer;
        }
    }

    private Image sockImageDisplayer;

    public void Config(ItemConfig config)
    {
        SockColor = config.ItemColor;
        SockImageDisplayer.sprite = config.ItemImage;

        if(defaultParent == null)
        {
            defaultParent = ItemTransform.parent;

            if (defaultPosition == Vector2.zero)
            {
                defaultPosition = ItemTransform.position;
            }
        }

        ItemTransform.SetParent(defaultParent);
        ItemTransform.position = defaultPosition;

        ShowItem();
    }

    public override void OnDrag(PointerEventData eventData)
        => base.OnDrag(eventData);
}
