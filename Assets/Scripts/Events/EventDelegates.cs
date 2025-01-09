public static class EventDelegates
{
    #region Delegates
    public delegate void EventDelegate();
    #endregion

    #region Events
    public static event EventDelegate _OnRoundStartedEvent;
    public static event EventDelegate _OnRoundCompletedEvent;
    #endregion

    #region Callbacks
    public static void OnRoundStartedEvent() => _OnRoundStartedEvent?.Invoke();
    public static void OnRoundCompletedEvent() => _OnRoundCompletedEvent?.Invoke();
    #endregion
}

public static class EventDelegates<T>
{
    #region Delegates
    public delegate void EventDelegate(T value);
    #endregion

    #region Events
    public static event EventDelegate _OnDialogueChangeEvent;
    public static event EventDelegate _OnSubmittedResultsEvent;
    #endregion

    #region Callbacks
    public static void OnDialogueChangeEvent(T value) => _OnDialogueChangeEvent?.Invoke(value);
    public static void OnSubmittedResultsEvent(T value) => _OnSubmittedResultsEvent?.Invoke(value);
    #endregion
}
