using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookAI : MonoBehaviour
{
    public BookStateMachine StateMachine { get; set; }
    public UserInput ui;

    public Page[] p;

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
        if (currPage == p.Length)
            return;

        if (currPage == 0)
        {
            p[currPage].rotateToYRotation(180f, 1);

            p[currPage + 1].rotateToYRotation(11.0f, 1);
            p[currPage + 1].blendCurlDown(65, 1);
        }
        else if (currPage == p.Length - 2)
        {
            for (int i = 0; i < currPage; i++)
            {
                p[i].moveZPosition(0.2f, 1);
            }

            //flatten out page now hidden page
            p[currPage - 1].rotateToYRotation(180f, 1);
            p[currPage - 1].spineCurlUp(0, 1);

            //flip over page
            p[currPage].FlipLeft();

            //curl corner of page
            p[currPage].pageCurlUp(100, 0.3f);
            p[currPage].pageCurlUp(0.7f, 0, 0.3f);
        }
        else if (currPage == p.Length - 1)
        {
            //lower all left side pages
            for (int i = 0; i < currPage; i++)
            {
                p[i].moveZPosition(0.2f, 1);
            }

            //flatten out page now hidden page
            p[currPage - 1].rotateToYRotation(180f, 1);
            p[currPage - 1].spineCurlUp(0, 1);

            //flips over backcover
            p[currPage].rotateToYRotation(180f, 1);
        }
        else
        {

            //lower all left side pages
            for (int i = 0; i < currPage; i++)
            {
                p[i].moveZPosition(0.2f, 1);
            }

            //flatten out page now hidden page
            p[currPage - 1].rotateToYRotation(180f, 1);
            p[currPage - 1].spineCurlUp(0, 1);

            //flip over page
            p[currPage].FlipLeft();
            //curl corner of page
            p[currPage].pageCurlUp(100, 0.3f);
            p[currPage].pageCurlUp(0.7f, 0, 0.3f);

            //raise up newly revealed page
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
            p[currPage - 1].rotateToYRotation(0.0f, 1);

            p[currPage].rotateToYRotation(0.0f, 1);
            p[currPage].blendCurlDown(0, 1);
        }
        else if (currPage == 2)
        {
            for (int i = 0; i < currPage - 1; i++)
            {
                p[i].moveZPosition(-0.2f, 1);
            }

            p[currPage - 1].FlipRight();

            //curl corner of page
            p[currPage - 1].pageCurlDown(100, 0.3f);
            p[currPage - 1].pageCurlDown(0.7f, 0, 0.3f);

            p[currPage].rotateToYRotation(0, 1);
            p[currPage].blendCurlDown(0, 1);
        }
        else if (currPage == p.Length)
        {
            for (int i = 0; i < currPage - 1; i++)
            {
                p[i].moveZPosition(-0.2f, 1);
            }

            p[currPage - 1].rotateToYRotation(0, 1);

            p[currPage - 2].rotateToYRotation(169, 1);
            p[currPage - 2].spineCurlUp(65, 1);
        }
        else
        {
            for (int i = 0; i < currPage - 1; i++)
            {
                p[i].moveZPosition(-0.2f, 1);
            }

            p[currPage - 2].rotateToYRotation(169, 1);
            p[currPage - 2].spineCurlUp(65, 1);

            p[currPage - 1].FlipRight();

            //curl corner of page
            p[currPage - 1].pageCurlDown(100, 0.3f);
            p[currPage - 1].pageCurlDown(0.7f, 0, 0.3f);

            p[currPage].rotateToYRotation(0, 1);
            p[currPage].blendCurlDown(0, 1);
        }

        currPage--;
    }
}
