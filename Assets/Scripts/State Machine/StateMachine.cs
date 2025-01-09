using UnityEngine;

// StateMachine<T> Class:
// This is an abstract base class for implementing a state machine pattern. It allows for managing states of a given type T.
// The state machine ensures that only one state is active at a time and provides functionality to transition between states.
// It is generic, with T constrained to be a type of Object, enabling flexibility for different types of state machine implementations.
//
// Key Features:
// - **CurrentState**: A property that holds the current active state of the machine.
// - **SetCurrentState(State state)**: This method allows the state machine to transition to a new state. 
//   - If there is an existing current state, it will call `OnExit()` on it before transitioning.
//   - After the transition, it will call `OnEnter()` on the new state.

public abstract class StateMachine<T> : Singletons<T> where T : Object
{
    // Property representing the current active state of the machine.
    public State CurrentState { get; private set; }

    // Virtual method to set the current state of the machine.
    // It ensures that the previous state (if any) calls its OnExit method before transitioning to the new state.
    // The new state calls its OnEnter method to initialize itself.
    public virtual void SetCurrentState(State state)
    {
        // Check if there is an existing state and exit it.
        if (CurrentState != null)
        {
            CurrentState.OnExit(); // Call OnExit for the current state.
        }

        // Set the new state as the current state.
        CurrentState = state;

        // Call OnEnter for the new state to initialize it.
        CurrentState.OnEnter();
    }
}

