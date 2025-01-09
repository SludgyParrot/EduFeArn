public static class EventDelegates<T>
{
    #region Delegates
    public delegate void EventDelegate();
    public delegate void EventDelegate<T>(T value);
    #endregion

    #region Events
    public static event EventDelegate<T> _OnDialogueChangeEvent;

    #endregion

    #region Callbacks
    public static void OnDialogueChangeEvent(T value) => _OnDialogueChangeEvent?.Invoke(value);
    #endregion
}
