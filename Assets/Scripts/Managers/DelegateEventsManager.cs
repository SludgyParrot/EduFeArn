using System;
using System.Linq;

using static GlobalEnums;

// DelegateEventsManager Class:
// This class is responsible for managing event subscriptions, invocations, and unsubscriptions for various event types.
// It allows for flexible event handling with or without parameters, based on the event type specified.
//
// Key Features:
// - **RegisterEvents**: Allows the registration of event handlers (functions) for specific event types (either with or without parameters).
// - **InvokeEvents**: Triggers events and invokes the associated handlers. Can invoke events with or without parameters.
// - **UnRegisterEvents**: Unsubscribes event handlers (functions) from specific event types.
//
// This is useful in systems where dynamic event handling is required, such as in game development, UI systems, or other event-driven applications.
// Events are triggered by their respective event types, and this class provides a centralized manager for event handling.

public class DelegateEventsManager : Singletons<DelegateEventsManager>
{
    #region Subsribe Events
    // Method to register event handlers for events that do not take parameters.
    public void RegisterEvents(params (Action function, DelegateEventType eventType)[] eventArgs)
    {
        // Check if no event arguments are passed.
        if (eventArgs.Length == 0)
        {
            throw new ArgumentException("Register Events failed: There are no event args passed.");
        }

        // Iterate over the event arguments and register each event handler.
        eventArgs.ToList().ForEach(eventData =>
        {
            switch (eventData.eventType)
            {
                case DelegateEventType.OnRoundStartedEvent:
                    // Register function for the OnRoundStartedEvent.
                    EventDelegates._OnRoundStartedEvent += () => eventData.function.Invoke();
                    break;
                case DelegateEventType.OnRoundCompletedEvent:
                    // Register function for the OnRoundEndedEvent.
                    EventDelegates._OnRoundCompletedEvent += () => eventData.function.Invoke();
                    break;
            }
        });
    }

    // Method to register event handlers for events with parameters of type T.
    public void RegisterEvents<T>(params (Action<T> function, DelegateEventType eventType)[] eventArgs)
    {
        // Check if no event arguments are passed.
        if (eventArgs.Length == 0)
        {
            throw new ArgumentException("Register Events failed: There are no event args passed.");
        }

        // Iterate over the event arguments and register each event handler.
        eventArgs.ToList().ForEach(eventData =>
        {
            switch (eventData.eventType)
            {
                case DelegateEventType.OnDialogueChangeEvent:
                    // Register function for the OnDialogueChangeEvent with a parameter of type T.
                    EventDelegates<T>._OnDialogueChangeEvent += value => eventData.function.Invoke(value);
                    break;
                case DelegateEventType.OnSubmittedResultsEvent:
                    // Register function for the OnSubmittedResultsEvent with a parameter of type T.
                    EventDelegates<T>._OnSubmittedResultsEvent += value => eventData.function.Invoke(value);
                    break;
            }
        });
    }
    #endregion

    #region Invoke Events
    // Method to invoke events that do not take parameters.
    public void InvokeEvents(params DelegateEventType[] eventArgs)
    {
        // Check if no event arguments are passed.
        if (eventArgs.Length == 0)
        {
            throw new ArgumentException("Invoke Events failed: There are no events arguments passed.");
        }

        UnityEngine.Debug.Log($"Invoked Events starting with: {eventArgs.FirstOrDefault().ToString()}");

        // Iterate over the event arguments and invoke each event.
        eventArgs.ToList().ForEach(eventData =>
        {
            switch (eventData)
            {
                case DelegateEventType.OnRoundStartedEvent:
                    // Invoke the OnRoundStartedEvent.
                    EventDelegates.OnRoundStartedEvent();
                    break;
                case DelegateEventType.OnRoundCompletedEvent:
                    // Invoke the OnRoundCompletedEvent.
                    EventDelegates.OnRoundCompletedEvent();
                    break;
            }
        });
    }

    // Method to invoke events with parameters of type T.
    public void InvokeEvents<T>(params (T value, DelegateEventType eventType)[] eventArgs)
    {
        // Check if no event arguments are passed.
        if (eventArgs.Length == 0)
        {
            throw new ArgumentException("Invoke Events failed: There are no events arguments passed.");
        }

        // Iterate over the event arguments and invoke each event with the provided value of type T.
        eventArgs.ToList().ForEach((eventData) =>
        {
            switch (eventData.eventType)
            {
                case DelegateEventType.OnDialogueChangeEvent:
                    // Invoke the OnDialogueChangeEvent with the provided value of type T.
                    EventDelegates<T>.OnDialogueChangeEvent(eventData.value);
                    break;
                case DelegateEventType.OnSubmittedResultsEvent:
                    // Invoke the OnSubmittedResultsEvent with the provided value of type T.
                    EventDelegates<T>.OnSubmittedResultsEvent(eventData.value);
                    break;
            }
        });
    }
    #endregion

    #region UnSubscribe Events
    // Method to unregister event handlers for events that do not take parameters.
    public void UnRegisterEvents(params (Action function, DelegateEventType eventType)[] eventArgs)
    {
        // Check if no event arguments are passed.
        if (eventArgs.Length == 0)
        {
            throw new ArgumentException("Register Events failed: There are no event args passed.");
        }

        // Iterate over the event arguments and unregister each event handler.
        eventArgs.ToList().ForEach(eventData =>
        {
            switch (eventData.eventType)
            {
                case DelegateEventType.OnRoundStartedEvent:
                    // Unregister function from the OnRoundStartedEvent.
                    EventDelegates._OnRoundStartedEvent -= () => eventData.function.Invoke();
                    break;
                case DelegateEventType.OnRoundCompletedEvent:
                    // Unregister function from the OnRoundCompletedEvent.
                    EventDelegates._OnRoundCompletedEvent -= () => eventData.function.Invoke();
                    break;
            }
        });
    }

    // Method to unregister event handlers for events with parameters of type T.
    public void UnRegisterEvents<T>(params (Action<T> function, DelegateEventType eventType)[] eventArgs)
    {
        // Check if no event arguments are passed.
        if (eventArgs.Length == 0)
        {
            throw new ArgumentException("Register Events failed: There are no event args passed.");
        }

        // Iterate over the event arguments and unregister each event handler.
        eventArgs.ToList().ForEach(eventData =>
        {
            switch (eventData.eventType)
            {
                case DelegateEventType.OnDialogueChangeEvent:
                    // Unregister function from the OnDialogueChangeEvent.
                    EventDelegates<T>._OnDialogueChangeEvent -= value => eventData.function.Invoke(value);
                    break;
                case DelegateEventType.OnSubmittedResultsEvent:
                    // Unregister function from the OnSubmittedResultsEvent.
                    EventDelegates<T>._OnSubmittedResultsEvent -= value => eventData.function.Invoke(value);
                    break;
            }
        });
    }
    #endregion
}
