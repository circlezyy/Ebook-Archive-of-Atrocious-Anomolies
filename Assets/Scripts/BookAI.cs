using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookAI : MonoBehaviour
{
    public BookStateMachine StateMachine { get; set; }
    public UserInput ui;

    public Page[] p;

    public int changes = 0;
    public int currPage = 0;
    public float rate;

    private void Start()
    {
        StateMachine = new BookStateMachine(this.gameObject);
        StateMachine.Initialize();
    }

    private void Update()
    {
        StateMachine.Update();
    }

    public void TurnToPage(string p)
    {
        if (changes == 0)
        {
            int pagenum = int.Parse(p);
            if (pagenum > currPage)
                StartCoroutine(TurnForwardToPageI(pagenum));
            else if (pagenum < currPage)
                StartCoroutine(TurnBackToPageI(pagenum));
        }
    }

    IEnumerator TurnForwardToPageI(int pagenum)
    {
        changes++;
        while(pagenum > currPage)
        {
            if (changes == 1)
                TurnForward();
            yield return null;
        }
        changes--;
    }

    IEnumerator TurnBackToPageI(int pagenum)
    {
        changes++;
        while (pagenum < currPage)
        {
            if (changes == 1)
                TurnBack();
            yield return null;
        }
        changes--;
    }

    public void TurnForward()
    {
        ui.ClearInput();
        if (currPage == p.Length)
            return;

        if (currPage == 0)
        {
            p[currPage].rotateToYRotation(180f, 1 * rate);

            p[currPage + 1].rotateToYRotation(11.0f, 1 * rate);
            p[currPage + 1].blendCurlDown(65, 1 * rate);
        }
        else if (currPage == p.Length - 2)
        {
            for (int i = 0; i < currPage; i++)
            {
                p[i].moveZPosition(0.2f, 1 * rate);
            }

            //flatten out page now hidden page
            p[currPage - 1].rotateToYRotation(180f, 1 * rate);
            p[currPage - 1].spineCurlUp(0, 1 * rate);

            //flip over page
            p[currPage].FlipLeft(rate);

            //curl corner of page
            p[currPage].pageCurlUp(100, 0.3f * rate);
            p[currPage].pageCurlUp(0.7f * rate, 0, 0.3f * rate);
        }
        else if (currPage == p.Length - 1)
        {
            //lower all left side pages
            for (int i = 0; i < currPage; i++)
            {
                p[i].moveZPosition(0.2f, 1 * rate);
            }

            //flatten out page now hidden page
            p[currPage - 1].rotateToYRotation(180f, 1 * rate);
            p[currPage - 1].spineCurlUp(0, 1 * rate);

            //flips over backcover
            p[currPage].rotateToYRotation(180f, 1 * rate);
        }
        else
        {

            //lower all left side pages
            for (int i = 0; i < currPage; i++)
            {
                p[i].moveZPosition(0.2f, 1 * rate);
            }

            //flatten out page now hidden page
            p[currPage - 1].rotateToYRotation(180f, 1 * rate);
            p[currPage - 1].spineCurlUp(0, 1 * rate);

            //flip over page
            p[currPage].FlipLeft(rate);
            //curl corner of page
            p[currPage].pageCurlUp(100, 0.3f * rate);
            p[currPage].pageCurlUp(0.7f * rate, 0, 0.3f * rate);

            //raise up newly revealed page
            p[currPage + 1].rotateToYRotation(11.0f, 1 * rate);
            p[currPage + 1].blendCurlDown(65, 1 * rate);
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
            p[currPage - 1].rotateToYRotation(0.0f, 1 * rate);

            p[currPage].rotateToYRotation(0.0f, 1 * rate);
            p[currPage].blendCurlDown(0, 1 * rate);
        }
        else if (currPage == 2)
        {
            for (int i = 0; i < currPage - 1; i++)
            {
                p[i].moveZPosition(-0.2f, 1 * rate);
            }

            p[currPage - 1].FlipRight(rate);

            //curl corner of page
            p[currPage - 1].pageCurlDown(100, 0.3f * rate);
            p[currPage - 1].pageCurlDown(0.7f * rate, 0, 0.3f * rate);

            p[currPage].rotateToYRotation(0, 1 * rate);
            p[currPage].blendCurlDown(0, 1 * rate);
        }
        else if (currPage == p.Length)
        {
            for (int i = 0; i < currPage - 1; i++)
            {
                p[i].moveZPosition(-0.2f, 1 * rate);
            }

            p[currPage - 1].rotateToYRotation(0, 1 * rate);

            p[currPage - 2].rotateToYRotation(169, 1 * rate);
            p[currPage - 2].spineCurlUp(65, 1 * rate);
        }
        else
        {
            for (int i = 0; i < currPage - 1; i++)
            {
                p[i].moveZPosition(-0.2f, 1 * rate);
            }

            p[currPage - 2].rotateToYRotation(169, 1 * rate);
            p[currPage - 2].spineCurlUp(65, 1 * rate);

            p[currPage - 1].FlipRight(rate);

            //curl corner of page
            p[currPage - 1].pageCurlDown(100, 0.3f * rate);
            p[currPage - 1].pageCurlDown(0.7f * rate, 0, 0.3f * rate);

            p[currPage].rotateToYRotation(0, 1 * rate);
            p[currPage].blendCurlDown(0, 1 * rate);
        }

        currPage--;
    }
}
