using System;
using System.Collections.Generic;
using UnityEngine;

using static GlobalEnums;

public class AssessmentStateManager : StateMachine<AssessmentStateManager>
{
    [SerializeField]
    private State entryState;

    public ItemColor RequiredItemColor { get; set; }
    public int RequiredItemCount{ get; set; }

    private List<ItemColor> requiredItems;

    public bool Retry {  get; set; }

    public void CheckResults(ItemColor item, Action<bool> callback = null)
    {
        if (item != RequiredItemColor)
        {
            DelegateEventsManager.Instance.InvokeEvents((ResultsType.Incorrect, DelegateEventType.OnSubmittedResultsEvent));
            callback?.Invoke(false);
            return;
        }

        requiredItems.Add(item);

        if (requiredItems.Count == RequiredItemCount)
        {
            DelegateEventsManager.Instance.InvokeEvents((ResultsType.Correct, DelegateEventType.OnSubmittedResultsEvent));
        }
        else
        {
            callback?.Invoke(true);
        }
    }

    private void OnEnable()
    {
        DelegateEventsManager.Instance.RegisterEvents((AssessmentStateManager_OnRoundStartedEvent, DelegateEventType.OnRoundStartedEvent));
    }

    private void OnDisable()
    {
        DelegateEventsManager.Instance.UnregisterEvents((AssessmentStateManager_OnRoundStartedEvent, DelegateEventType.OnRoundStartedEvent));
    }

    protected override void Init()
    {
        base.Init();

        if(entryState == null )
        {
            throw new InvalidOperationException("RoundManager initialization failed: entry state cannot be null.");
        }

        SetCurrentState(entryState);
    }

    private void AssessmentStateManager_OnRoundStartedEvent()
    {
        requiredItems = new List<ItemColor>();
    }
}
