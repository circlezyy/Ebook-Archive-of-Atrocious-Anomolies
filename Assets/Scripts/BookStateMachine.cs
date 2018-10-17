using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**** Opening ***
 * 
 * ClosedFrontCoverFacingUpState
 * --OpenFrontCoverState
 * Page1UpState
 * --OpenPage1State
 * Page2UpState
 * 
 */

public class BookStateMachine
{

    public IState currentState { get; private set; }
    public GameObject Owner;

    public IState closedFrontCoverFacingUpState;
    public IState page1UpState;
    public IState page2UpState;

    public IState openFrontCoverState;
    public IState closeFrontCoverState;

    public IState openPage1State;
    public IState closePage1State;

    public BookStateMachine(GameObject o)
    {
        Owner = o;

        closedFrontCoverFacingUpState = new ClosedFrontCoverFacingUpState(this);
        page1UpState = new Page1UpState(this);
        page2UpState = new Page2UpState(this);

        openFrontCoverState = new OpenFrontCoverState(this);
        closeFrontCoverState = new CloseFrontCoverState(this);

        openPage1State = new OpenPage1State(this);
        closePage1State = new ClosePage1State(this);

        currentState = closedFrontCoverFacingUpState;
    }

    public void ChangeState(IState newState)
    {
        Debug.Log(newState);

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
