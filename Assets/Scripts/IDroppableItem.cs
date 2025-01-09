using UnityEngine;

public interface IDroppableItem
{
    void ShowItem();
    void HideItem();

    void SetParent(RectTransform parent);
}
