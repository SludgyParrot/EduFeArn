using System;
using UnityEngine;

[Serializable]
public abstract class State : ScriptableObject
{
    [field: SerializeField]
    public string MessageOverride { get; private set; }

    [field: SerializeField]
    public AudioClip AudioClipOverride { get; private set; }

    [field: SerializeField]
    protected State ExitState { get; private set; }

    public abstract void OnEnter();
    public abstract void OnExit();
}
