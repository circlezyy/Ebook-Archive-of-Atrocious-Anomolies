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
        ui.ClearInput();

        if (currPage == p.Length - 1)
            return;

        if (currPage == 0)
        {
            p[0].rotateToYRotation(180f, 1);

            p[1].rotateToYRotation(11.0f, 1);
            p[1].blendCurlDown(65, 1);
        }
        else
        {
            for (int i = 0; i < currPage; i++)
            {
                p[i].moveZPosition(0.2f, 1);
            }

            p[currPage].FlipLeft();

            p[currPage + 1].rotateToYRotation(11.0f, 1);
            p[currPage + 1].blendCurlDown(65, 1);
        }

        currPage++;
    }

    public void TurnBack()
    {
        ui.ClearInput();

        if (currPage == 0)
            return;

        if (currPage == 1)
        {
            p[0].rotateToYRotation(0.0f, 1);
            p[1].rotateToYRotation(0.0f, 1);
            p[1].blendCurlDown(0, 1);
        }
        else
        {
            for (int i = 0; i < currPage - 1; i++)
            {
                p[i].moveZPosition(-0.2f, 1);
            }

            p[currPage - 1].FlipRight();

            p[currPage].rotateToYRotation(0, 1);
            p[currPage].blendCurlDown(0, 1);
        }
        //case 4:
        //    p[0].moveZPosition(-0.2f, 1);
        //    p[1].moveZPosition(-0.2f, 1);
        //    p[2].moveZPosition(-0.2f, 1);

        //    p[3].FlipRight();

        //    p[4].rotateToYRotation(0, 1);
        //    p[4].blendCurlDown(0, 1);

        //    break;
        //case 3:
        //    p[0].moveZPosition(-0.2f, 1);
        //    p[1].moveZPosition(-0.2f, 1);

        //    p[2].FlipRight();

        //    p[3].rotateToYRotation(0, 1);
        //    p[3].blendCurlDown(0, 1);

        //    break;
        //case 2:
        //    p[0].moveZPosition(-0.2f, 1);

        //    p[1].FlipRight();

        //    p[2].rotateToYRotation(0.0f, 1);
        //    p[2].blendCurlDown(0, 1);

        //    break;
        //case 1:
        //p[0].rotateToYRotation(0.0f, 1);
        //p[1].rotateToYRotation(0.0f, 1);
        //p[1].blendCurlDown(0, 1);

        //break;
        //    default:
        //        break;
        //}
        currPage--;
    }
}
