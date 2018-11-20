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

    public void HideInteractables()
    {
        StartCoroutine(IHideInteractables());
    }

    public void RevealInteractables()
    {
        StartCoroutine(IRevealInteractables());
    }

    IEnumerator IHideInteractables()
    {
        changes++;
        transform.GetComponent<Floating>().hideInteractables(currPage);
        yield return new WaitForSeconds(1f);
        changes--;
    }

    IEnumerator IRevealInteractables()
    {
        changes++;
        transform.GetComponent<Floating>().revealInteractables(currPage);
        yield return new WaitForSeconds(1f);
        changes--;
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
            //p[currPage].SetActiveCanvasBack(true);
            //p[currPage + 1].SetActiveCanvasFront(true);

            p[currPage].CoverLeft();
            p[currPage + 1].PageRightRise();
        }
        else
        {
            for (int i = 0; i < currPage; i++)
                p[i].moveDown();

            if (currPage == p.Length - 2)
            {
                //p[currPage - 1].SetActiveCanvasBack(false);
                //p[currPage].SetActiveCanvasFront(false);
                //p[currPage].SetActiveCanvasBack(true);
                //p[currPage + 1].SetActiveCanvasFront(true);

                p[currPage - 1].PageLeftFlatten();
                p[currPage].PageFlipLeft();
            }
            else if (currPage == p.Length - 1)
            {
                //p[currPage - 1].SetActiveCanvasBack(false);
                //p[currPage].SetActiveCanvasFront(false);
                //p[currPage].SetActiveCanvasBack(true);

                p[currPage - 1].PageLeftFlatten();
                p[currPage].CoverLeft();
            }
            else
            {
                //p[currPage - 1].SetActiveCanvasBack(false);
                //p[currPage].SetActiveCanvasFront(false);
                //p[currPage].SetActiveCanvasBack(true);
                //p[currPage + 1].SetActiveCanvasFront(true);


                p[currPage - 1].PageLeftFlatten();
                p[currPage].PageFlipLeft();
                p[currPage + 1].PageRightRise();
            }
        }

        currPage++;
    }

    public void TurnBack()
    {
        ui.ClearInput();

        //At beginning of book, no more pages to turn
        if (currPage == 0)
            return;


        if (currPage == 1)
        {
            //p[currPage - 1].SetActiveCanvasBack(false);
            //p[currPage].SetActiveCanvasFront(false);

            p[currPage - 1].CoverRight();
            p[currPage].PageRightFlatten();
        }
        else
        {
            for (int i = 0; i < currPage - 1; i++)
                p[i].moveUp();

            if (currPage == 2)
            {
                //p[currPage - 2].SetActiveCanvasBack(true);
                //p[currPage - 1].SetActiveCanvasFront(true);
                //p[currPage - 1].SetActiveCanvasBack(false);
                //p[currPage].SetActiveCanvasFront(false);

                p[currPage - 1].PageFlipRight();
                p[currPage].PageRightFlatten();
                //don't raise up front cover
            }
            else if (currPage == p.Length)
            {
                //p[currPage - 2].SetActiveCanvasBack(true);
                //p[currPage - 1].SetActiveCanvasFront(true);
                //p[currPage - 1].SetActiveCanvasBack(false);

                p[currPage - 2].PageLeftRise();
                p[currPage - 1].CoverRight();
            }
            else
            {
                //p[currPage - 2].SetActiveCanvasBack(true);
                //p[currPage - 1].SetActiveCanvasFront(true);
                //p[currPage - 1].SetActiveCanvasBack(false);
                //p[currPage].SetActiveCanvasFront(false);

                p[currPage - 2].PageLeftRise();
                p[currPage - 1].PageFlipRight();
                p[currPage].PageRightFlatten();
            }
        }

        currPage--;
    }
}
