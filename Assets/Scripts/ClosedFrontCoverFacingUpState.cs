using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosedFrontCoverFacingUpState : IState
{
    private readonly BookStateMachine stateMachine;
    private readonly BookAI ai;

    public ClosedFrontCoverFacingUpState(BookStateMachine sm)
    {
        stateMachine = sm;
        ai = sm.Owner.GetComponent<BookAI>();
    }

    public void EnterState(GameObject owner)
    {
        // set initial closed position
        ai.fc.setPosition(new Vector3(0, 0, 0));
        ai.fc.setYRotation(0);
        ai.fc.setCurlUp(0);

        ai.p1.setPosition(new Vector3(0, 0, 0.1f));
        ai.p1.setYRotation(0);
        ai.p1.setCurlUp(0);

        ai.p2.setPosition(new Vector3(0, 0, 0.2f));
        ai.p2.setYRotation(0);
        ai.p2.setCurlUp(0);

        ai.p3.setPosition(new Vector3(0, 0, 0.3f));
        ai.p3.setYRotation(0);
        ai.p3.setCurlUp(0);

        ai.p4.setPosition(new Vector3(0, 0, 0.4f));
        ai.p4.setYRotation(0);
        ai.p4.setCurlUp(0);

        ai.p5.setPosition(new Vector3(0, 0, 0.5f));
        ai.p5.setYRotation(0);
        ai.p5.setCurlUp(0);

        ai.p6.setPosition(new Vector3(0, 0, 0.6f));
        ai.p6.setYRotation(0);
        ai.p6.setCurlUp(0);

        ai.p7.setPosition(new Vector3(0, 0, 0.7f));
        ai.p7.setYRotation(0);
        ai.p7.setCurlUp(0);

        ai.p8.setPosition(new Vector3(0, 0, 0.8f));
        ai.p8.setYRotation(0);
        ai.p8.setCurlUp(0);

        ai.p9.setPosition(new Vector3(0, 0, 0.9f));
        ai.p9.setYRotation(0);
        ai.p9.setCurlUp(0);

        ai.bc.setPosition(new Vector3(0, 0, 1.0f));
        ai.bc.setYRotation(0);
        ai.bc.setCurlUp(0);

        ai.ui.ClearInput();
    }

    public void ExitState(GameObject owner)
    {
    }

    public void UpdateState(GameObject owner)
    {
        if (ai.ui.turnLeft)
        {
            stateMachine.ChangeState(stateMachine.openFrontCoverState);
        }
    }
}

