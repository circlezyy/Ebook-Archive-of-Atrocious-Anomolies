using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPage1State : IState
{
    private readonly BookStateMachine stateMachine;
    private readonly BookAI ai;

    public OpenPage1State(BookStateMachine sm)
    {
        stateMachine = sm;
        ai = sm.Owner.GetComponent<BookAI>();
    }

    public void EnterState(GameObject owner)
    {
        ai.fc.moveZPosition(0.2f, 1);

        ai.p1.rotateToYRotation(169f, 150.0f);
        ai.p1.blendCurlDown(0, 150.0f);
        ai.p1.blendCurlUp(65, 150.0f);

        ai.p2.rotateToYRotation(11.0f, 100.0f);
        ai.p2.blendCurlDown(65, 150.0f);
    }

    public void ExitState(GameObject owner)
    {
    }

    public void UpdateState(GameObject owner)
    {
        if (ai.p1.changes == 0)
        {
            stateMachine.ChangeState(stateMachine.page2UpState);
        }
    }
}