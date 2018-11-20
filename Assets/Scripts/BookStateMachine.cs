using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookStateMachine
{
    public IState currentState { get; private set; }
    public GameObject Owner;

    public IState notTurningState;
    public IState hideInteractables;
    public IState revealInteractables;
    public IState forwardState;
    public IState backState;


    public BookStateMachine(GameObject o)
    {
        Owner = o;

        notTurningState = new NotTurningState(this);
        hideInteractables = new HideInteractables(this);
        forwardState = new ForwardState(this);
        revealInteractables = new RevealInteractables(this);
        backState = new BackState(this);

        currentState = notTurningState;
    }

    public void ChangeState(IState newState)
    {
        if (currentState != null)
            currentState.ExitState(Owner);

        currentState = newState;
        currentState.EnterState(Owner);
    }

    public void Initialize()
    {
        if (currentState != null)
            currentState.EnterState(Owner);
    }


    public void Update()
    {
        if (currentState != null)
            currentState.UpdateState(Owner);
    }
}
