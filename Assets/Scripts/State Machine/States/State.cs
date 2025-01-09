using System;
using UnityEngine;

// State Class:
// This is an abstract base class for representing a state in a state machine.
// It is designed as a ScriptableObject, allowing the state to be created and assigned within Unity's asset system.
// States define behaviors for entering and exiting the state, and can optionally override messages and audio clips 
// when transitioning to or from the state.
//
// Key Features:
// - **MessageOverride**: A string property that can be used to override messages associated with this state (serialized for Unity Inspector).
// - **AudioClipOverride**: An audio clip that can be played when entering or exiting this state (serialized for Unity Inspector).
// - **ExitState**: A reference to another state that will be transitioned to once this state exits (serialized for Unity Inspector).
// - **OnEnter()**: Abstract method that defines behavior when this state is entered.
// - **OnExit()**: Abstract method that defines behavior when this state is exited.

[Serializable]
public abstract class State : ScriptableObject
{
    // A message override for the state, serialized to be set in the Unity Inspector.
    [field: SerializeField]
    public string MessageOverride { get; private set; }

    // An audio clip override for the state, serialized to be set in the Unity Inspector.
    [field: SerializeField]
    public AudioClip AudioClipOverride { get; private set; }

    // The state to transition to when this state exits, serialized for setting in the Unity Inspector.
    [field: SerializeField]
    protected State ExitState { get; private set; }

    // Abstract method called when the state is entered.
    // Derived classes should implement specific behavior for entering this state.
    public abstract void OnEnter();

    // Abstract method called when the state is exited.
    // Derived classes should implement specific behavior for exiting this state.
    public abstract void OnExit();
}

