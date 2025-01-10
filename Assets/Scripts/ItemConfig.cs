using UnityEngine;

using static GlobalEnums;

[CreateAssetMenu(fileName = "Item Config", menuName = "EduFeArn/Config Data/Item Config")]
public class ItemConfig : ScriptableObject
{
    public ItemColor ItemColor;
    public Sprite ItemImage;
}
