using UnityEngine;

/// <summary>
/// A generic singleton pattern implementation for MonoBehaviour-derived classes in Unity.
/// This class ensures that only one instance of a given type exists during the game lifetime.
/// It also provides an optional setting to prevent the singleton instance from being destroyed when loading a new scene.
/// </summary>
/// <typeparam name="T">The type of the class that is a singleton (must inherit from Unity's Object).</typeparam>
public class Singletons<T> : MonoBehaviour where T : Object
{
    [SerializeField]
    private bool dontDestroyOnLoad;

    private static T instance;

    public static T Instance
    {
        get 
        { 
            if(instance == null)
            {
                instance = FindObjectOfType<T>();  
            }

            return instance; 
        }
    }


    private void Awake()
        => Init();

    protected virtual void Init()
    {
        if(dontDestroyOnLoad)
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
