using System.Threading.Tasks;
using UnityEngine;

using static GlobalEnums;

[CreateAssetMenu(fileName = "Dialogue State", menuName = "EduFeArn/State Machine/Dialogue State")]
public class DialogueState : State
{
    [Space(5)]
    [SerializeField]
    private ItemColor requiredItemColor;

    [Space(5)]
    [SerializeField]
    public int requiredItemCount;

    [Space(5)]
    [SerializeField]
    private string incorrectResultsMessageOverride;

    public override async void OnEnter()
    {
        AssessmentStateManager.Instance.RequiredItemColor = requiredItemColor;
        AssessmentStateManager.Instance.RequiredItemCount = requiredItemCount;

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
        if(resultsType == ResultsType.Correct)
        {
            if (ExitState != null)
            {
                AssessmentStateManager.Instance.SetCurrentState(ExitState);
            }
        }
        else
        {
            DelegateEventsManager.Instance.InvokeEvents((incorrectResultsMessageOverride, DelegateEventType.OnDialogueChangeEvent));
            await Task.Delay(2000);
            AssessmentStateManager.Instance.SetCurrentState(this);
        }
    }

    public override void OnExit()
    {
        DelegateEventsManager.Instance.UnRegisterEvents<ResultsType>((DialogueState_OnSubmittedResultsEvent, DelegateEventType.OnSubmittedResultsEvent));
    }
}
