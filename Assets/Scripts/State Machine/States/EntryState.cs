using System.Threading.Tasks;
using UnityEngine;

using static GlobalEnums;

[CreateAssetMenu(fileName = "Entry State", menuName = "EduFeArn/State Machine/Entry State")]
public class EntryState : State
{
    public override async void OnEnter()
    {

        await Task.Delay(2000);

        Debug.Log("Entry state has entered");

        DelegateEventsManager.Instance.InvokeEvent(MessageOverride, DelegateEventType.OnDialogueChangeEvent);

        await Task.Delay(500);

        if (AudioClipOverride != null)
        {
            SoundManager.Instance.PlayClip(AudioClipOverride);
        }

        await Task.Delay(2000);


    }

    public override void OnExit()
    {
        Debug.Log("Entry state has exited.");
    }
}
