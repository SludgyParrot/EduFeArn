using System;
using UnityEngine;
using UnityEngine.UI;

using static GlobalEnums;

public class DialogueUIHandler : MonoBehaviour
{
    [SerializeField]
    private Text textDisplayer;

    private void OnEnable()
    {
        DelegateEventsManager.Instance.RegisterEvents<string>((SetDialogueText, DelegateEventType.OnDialogueChangeEvent));
    }

    private void SetDialogueText(string text)
    {
        if(textDisplayer == null)
        {
            throw new InvalidOperationException("Set dialogue text failed: text displayer cannot be null.");
        }

        textDisplayer.text = text;
    }

    private void OnDisable()
    {
        DelegateEventsManager.Instance.UnRegisterEvents<string>((SetDialogueText, DelegateEventType.OnDialogueChangeEvent));
    }
}
