using System;
using System.Threading.Tasks;
using UnityEngine;

using static GlobalEnums;

[CreateAssetMenu(fileName = "Dialogue State", menuName = "EduFeArn/State Machine/Dialogue State")]
public class DialogueState : State
{
    [Space(5)]
    [SerializeField]
    private ItemConfig[] stateConfigs;

    [Space(5)]
    [SerializeField]
    private ItemColor requiredItemColor;

    [Space(5)]
    [SerializeField]
    public int requiredItemCount;

    [Space(5)]
    [SerializeField]
    private string correctResultsMessageOverride,
                   incorrectResultsMessageOverride, 
                   completedResultsMessageOverride;

    public override async void OnEnter()
    {
        if(AssessmentStateManager.Instance.Completed)
        {
            return;
        }

        AssessmentStateManager.Instance.RequiredItemColor = requiredItemColor;
        AssessmentStateManager.Instance.RequiredItemCount = requiredItemCount;

        if(stateConfigs.Length > 0)
        {
            AssetsFactoryManager.Instance.CreateAssets(stateConfigs);
        }

        if(!AssessmentStateManager.Instance.Retry)
        {
            DelegateEventsManager.Instance.InvokeEvents(DelegateEventType.OnRoundStartedEvent);
        }

        await Task.Delay(2000);
        DelegateEventsManager.Instance.InvokeEvents((MessageOverride, DelegateEventType.OnDialogueChangeEvent));
        await Task.Delay(500);

        if (AudioClipOverride != null)
        {
            SoundManager.Instance.PlayClip(AudioClipOverride);
        }
        DelegateEventsManager.Instance.RegisterEvents<ResultsType>((DialogueState_OnSubmittedResultsEvent, DelegateEventType.OnSubmittedResultsEvent));
    }

    private async void DialogueState_OnSubmittedResultsEvent(ResultsType resultsType)
    {
        if(StateCompleted)
        {
            return;
        }

        AssessmentStateManager.Instance.ClearStateMachine();

        if (resultsType == ResultsType.Correct)
        {
            AssessmentStateManager.Instance.Retry = false;

            await Task.Delay(1000);

            if (ExitState == null)
            {
                DelegateEventsManager.Instance.InvokeEvents((completedResultsMessageOverride, DelegateEventType.OnDialogueChangeEvent));
                AssessmentStateManager.Instance.Completed = true;
                return;
            }

            DelegateEventsManager.Instance.InvokeEvents((correctResultsMessageOverride, DelegateEventType.OnDialogueChangeEvent));
            await Task.Delay(1000);
            DelegateEventsManager.Instance.InvokeEvents(DelegateEventType.OnRoundCompletedEvent);

            await Task.Delay(500);
            AssetsFactoryManager.Instance.HideAllSocks();
            await Task.Delay(2500);
            AssessmentStateManager.Instance.SetCurrentState(ExitState);
        }
        else
        {
            DelegateEventsManager.Instance.InvokeEvents((incorrectResultsMessageOverride, DelegateEventType.OnDialogueChangeEvent));
            AssetsFactoryManager.Instance.HideAllSocks();
            await Task.Delay(2000);
            AssessmentStateManager.Instance.Retry = true;
            AssessmentStateManager.Instance.SetCurrentState(this);
        }

        OnExit();
    }

    public override void OnExit()
    {
        StateCompleted = true;
        DelegateEventsManager.Instance.UnregisterEvents<ResultsType>((DialogueState_OnSubmittedResultsEvent, DelegateEventType.OnSubmittedResultsEvent));
    }
}
