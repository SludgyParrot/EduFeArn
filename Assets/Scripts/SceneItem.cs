using UnityEngine;

/// <summary>
/// Represents a generic scene item that has a name and a RectTransform for positioning and scaling within the UI.
/// This class is designed to be used in UI elements that need to be manipulated in a 2D space, typically for drag-and-drop scenarios.
/// </summary>
[RequireComponent(typeof(RectTransform))]
public class SceneItem : MonoBehaviour
{
    [field: SerializeField]
    public string Name { get; private set; }

    public RectTransform ItemTransform
    {   get
        {
            if(itemTransform == null)
            {
                itemTransform = GetComponent<RectTransform>();
            }

            return itemTransform;
        }
    }

    private RectTransform itemTransform;
}
