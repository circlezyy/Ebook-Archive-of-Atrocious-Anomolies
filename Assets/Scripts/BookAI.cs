using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookAI : MonoBehaviour
{
    public BookStateMachine StateMachine { get; set; }
    public UserInput ui;

    public Page[] p;

    //public Page fc; //front cover
    //public Page p1;
    //public Page p2;
    //public Page p3;
    //public Page p4;
    //public Page p5;
    //public Page p6;
    //public Page p7;
    //public Page p8;
    //public Page p9;
    //public Page bc; //back cover

    public int currPage = 0;


    private void Start()
    {
        StateMachine = new BookStateMachine(this.gameObject);
        StateMachine.Initialize();
    }

    private void Update()
    {
        StateMachine.Update();
    }

    public void TurnForward()
    {


        if (currPage == 0)
        {
            p[0].rotateToYRotation(180f, 1);
            p[1].rotateToYRotation(11.0f, 1);
            p[1].blendCurlDown(65, 1);
            currPage++;
        }
        else if (currPage == 1)
        {
            p[0].moveZPosition(0.2f, 1);

            p[1].rotateToYRotation(169f, 1);
            p[1].blendCurlDown(0, 1);
            p[1].blendCurlUp(65, 1);

            p[2].rotateToYRotation(11.0f, 1);
            p[2].blendCurlDown(65, 1);
            currPage++;
        }
        ui.ClearInput();
    }

    public void TurnBack()
    {
        if (currPage == 2)
        {
            p[0].moveZPosition(-0.2f, 1);

            p[1].rotateToYRotation(11, 1);
            p[1].blendCurlDown(65, 1);
            p[1].blendCurlUp(0, 1);

            p[2].rotateToYRotation(0.0f, 1);
            p[2].blendCurlDown(0, 1);
            currPage--;
        }
        else if (currPage == 1)
        {
            p[0].rotateToYRotation(0.0f, 1);
            p[1].rotateToYRotation(0.0f, 1);
            p[1].blendCurlDown(0, 1);
            currPage--;
        }
        ui.ClearInput();
    }
}
