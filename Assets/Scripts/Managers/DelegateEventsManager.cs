using System;

using static GlobalEnums;

public class DelegateEventsManager : Singletons<DelegateEventsManager>
{
    public void RegisterEvent<T>(Action<T> function, DelegateEventType eventType)
    {
        switch(eventType)
        {
            case DelegateEventType.OnDialogueChangeEvent:
                EventDelegates<T>._OnDialogueChangeEvent += value => function.Invoke(value);
                break;
        }
    }

    public void InvokeEvent<T>(T value, DelegateEventType eventType)
    {
        switch(eventType)
        {
            case DelegateEventType.OnDialogueChangeEvent:
                EventDelegates<T>.OnDialogueChangeEvent(value);
                break;
        }
    }

    public void UnRegisterEvent<T>(Action<T> function, DelegateEventType eventType)
    {
        switch (eventType)
        {
            case DelegateEventType.OnDialogueChangeEvent:
                EventDelegates<T>._OnDialogueChangeEvent -= value => function.Invoke(value);
                break;
        }
    }
}
