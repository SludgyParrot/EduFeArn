using System.Threading.Tasks;
using UnityEngine;

using static GlobalEnums;

[CreateAssetMenu(fileName = "Dialogue Entry State", menuName = "EduFeArn/State Machine/Dialogue Entry State")]
public class DialogueEntryState : State
{
    public override async void OnEnter()
    {
        await Task.Delay(2000);
        DelegateEventsManager.Instance.InvokeEvents((MessageOverride, DelegateEventType.OnDialogueChangeEvent));
        await Task.Delay(500);
        if (AudioClipOverride != null)
        {
            SoundManager.Instance.PlayClip(AudioClipOverride);
        }
        await Task.Delay(2500);
        if (ExitState != null)
        {
            AssessmentStateManager.Instance.SetCurrentState(ExitState);
        }
    }

    public override void OnExit()
    {
       
    }
}
