using System;
using UnityEngine;

public class RoundManager : StateMachine<RoundManager>
{
    [SerializeField]
    private State entryState;

    protected override void Init()
    {
        base.Init();

        if(entryState == null )
        {
            throw new InvalidOperationException("RoundManager initialization failed: entry state cannot be null.");
        }

        SetCurrentState(entryState);
    }
}
