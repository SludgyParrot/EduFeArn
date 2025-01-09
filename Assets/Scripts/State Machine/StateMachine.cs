using UnityEngine;

public abstract class StateMachine<T> : Singletons<T> where T: Object 
{
    public State CurrentState { get; private set; }

    protected virtual void SetCurrentState(State state)
    {
        if(CurrentState != null)
        {
            CurrentState.OnExit();
        }

        CurrentState = state;
        CurrentState.OnEnter();
    }    
}
