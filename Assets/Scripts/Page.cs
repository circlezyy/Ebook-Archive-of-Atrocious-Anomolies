using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page : MonoBehaviour
{
    public BookAI bai;
    public GameObject CanvasFront;
    public GameObject CanvasBack;

    public void Start()
    {
        bai = transform.GetComponentInParent<BookAI>();
        CanvasFront = transform.Find("CanvasFront").gameObject;
        CanvasBack = transform.Find("CanvasBack").gameObject;
        SetActiveCanvasFront(false);
        SetActiveCanvasBack(false);
    }

    public void SetActiveCanvasFront(bool isActive)
    {
        //if (isActive)
        //{
        //    StartCoroutine("CanvasFadeIn", CanvasFront.GetComponent<Canvas>());
        //}
        //else
        //{
        //    StartCoroutine("CanvasFadeOut", CanvasFront.GetComponent<Canvas>());
        //}
        CanvasFront.SetActive(isActive);
    }

    public void SetActiveCanvasBack(bool isActive)
    {
        CanvasBack.SetActive(isActive);
    }

    private IEnumerator CanvasFadeIn(Canvas can)
    {
        yield return null;
    }

    private IEnumerator CanvasFadeOut(Canvas can)
    {
        yield return null;
    }

    public void CoverLeft()
    {
        rotateToYRotation(180f, 1 * bai.rate);
    }

    public void CoverRight()
    {
        rotateToYRotation(0.0f, 1 * bai.rate);
    }

    public void PageLeftRise()
    {
        rotateToYRotation(169, 1 * bai.rate);
        spineCurlUp(65, 1 * bai.rate);
    }

    public void PageRightRise()
    {
        rotateToYRotation(11.0f, 1 * bai.rate);
        spineCurlDown(65, 1 * bai.rate);
    }

    public void PageLeftFlatten()
    {
        rotateToYRotation(180f, 1 * bai.rate);
        spineCurlUp(0, 1 * bai.rate);
    }

    public void PageRightFlatten()
    {
        rotateToYRotation(0, 1 * bai.rate);
        spineCurlDown(0, 1 * bai.rate);
    }

    public void PageFlipLeft()
    {
        rotateToYRotation(169f, 1 * bai.rate);
        spineCurlDown(0, 1 * bai.rate);
        spineCurlUp(65, 1 * bai.rate);

        //curl corner of page
        pageCurlUp(100, 0.3f * bai.rate);
        pageCurlUp(0.7f * bai.rate, 0, 0.3f * bai.rate);
    }

    public void PageFlipRight()
    {
        rotateToYRotation(11f, 1 * bai.rate);
        spineCurlDown(65, 1 * bai.rate);
        spineCurlUp(0, 1 * bai.rate);

        //curl corner of page
        pageCurlDown(100, 0.3f * bai.rate);
        pageCurlDown(0.7f * bai.rate, 0, 0.3f * bai.rate);
    }

    public void moveDown()
    {
        moveZPosition(0.2f, 1 * bai.rate);
    }

    public void moveUp()
    {
        moveZPosition(-0.2f, 1 * bai.rate);
    }

    private void moveZPosition(float zChange, float timeToMove)
    {
        bai.changes++;
        StartCoroutine(moveZPositionI(zChange, timeToMove));
    }

    private IEnumerator moveZPositionI(float zChange, float timeToMove)
    {
        var currentPos = transform.position;
        var targetPos = new Vector3(transform.position.x,
                                    transform.position.y,
                                    transform.position.z + zChange);
        var t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / timeToMove;
            transform.position = Vector3.Lerp(currentPos, targetPos, t);
            yield return null;
        }
        bai.changes--;
    }

    private void pageCurlDown(float newCurlDown, float timeToMove)
    {
        bai.changes++;
        StartCoroutine(PageCurlDownI(newCurlDown, timeToMove));
    }

    private void pageCurlDown(float timeToWait, float newCurlDown, float timeToMove)
    {
        bai.changes++;
        StartCoroutine(PageCurlDownI(timeToWait, newCurlDown, timeToMove));
    }

    private IEnumerator PageCurlDownI(float newCurlDown, float timeToMove)
    {
        SkinnedMeshRenderer smr = transform.GetChild(0).GetComponent<SkinnedMeshRenderer>();
        float currCurlDown = smr.GetBlendShapeWeight(3);
        float temp;

        var t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / timeToMove;
            temp = Mathf.Lerp(currCurlDown, newCurlDown, t);
            smr.SetBlendShapeWeight(3, temp);
            yield return null;
        }
        bai.changes--;
    }

    private IEnumerator PageCurlDownI(float timeToWait, float newCurlDown, float timeToMove)
    {
        yield return new WaitForSeconds(timeToWait);

        SkinnedMeshRenderer smr = transform.GetChild(0).GetComponent<SkinnedMeshRenderer>();
        float currCurlDown = smr.GetBlendShapeWeight(3);
        float temp;

        var t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / timeToMove;
            temp = Mathf.Lerp(currCurlDown, newCurlDown, t);
            smr.SetBlendShapeWeight(3, temp);
            yield return null;
        }
        bai.changes--;
    }

    private void pageCurlUp(float newCurlUp, float timeToMove)
    {
        bai.changes++;
        StartCoroutine(PageCurlUpI(newCurlUp, timeToMove));
    }

    private void pageCurlUp(float timeToWait, float newCurlUp, float timeToMove)
    {
        bai.changes++;
        StartCoroutine(PageCurlUpI(timeToWait, newCurlUp, timeToMove));
    }

    private IEnumerator PageCurlUpI(float timeToWait, float newCurlUp, float timeToMove)
    {
        yield return new WaitForSeconds(timeToWait);

        SkinnedMeshRenderer smr = transform.GetChild(0).GetComponent<SkinnedMeshRenderer>();
        float currCurlUp = smr.GetBlendShapeWeight(2);
        float temp;

        var t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / timeToMove;
            temp = Mathf.Lerp(currCurlUp, newCurlUp, t);
            smr.SetBlendShapeWeight(2, temp);
            yield return null;
        }
        bai.changes--;
    }

    private IEnumerator PageCurlUpI(float newCurlUp, float timeToMove)
    {
        SkinnedMeshRenderer smr = transform.GetChild(0).GetComponent<SkinnedMeshRenderer>();
        float currCurlUp = smr.GetBlendShapeWeight(2);
        float temp;

        var t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / timeToMove;
            temp = Mathf.Lerp(currCurlUp, newCurlUp, t);
            smr.SetBlendShapeWeight(2, temp);
            yield return null;
        }
        bai.changes--;
    }

    private void spineCurlUp(float newCurlUp, float timeToMove)
    {
        bai.changes++;
        StartCoroutine(SpineCurlUpI(newCurlUp, timeToMove));
    }

    private IEnumerator SpineCurlUpI(float newCurlUp, float timeToMove)
    {
        SkinnedMeshRenderer smr = transform.GetChild(0).GetComponent<SkinnedMeshRenderer>();
        float currCurlUp = smr.GetBlendShapeWeight(1);
        float temp;

        var t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / timeToMove;
            temp = Mathf.Lerp(currCurlUp, newCurlUp, t);
            smr.SetBlendShapeWeight(1, temp);
            yield return null;
        }
        bai.changes--;
    }

    private void spineCurlDown(float newCurlDown, float timeToMove)
    {
        bai.changes++;
        StartCoroutine(SpineCurlDownI(newCurlDown, timeToMove));
    }

    private IEnumerator SpineCurlDownI(float newCurlDown, float timeToMove)
    {
        SkinnedMeshRenderer smr = transform.GetChild(0).GetComponent<SkinnedMeshRenderer>();
        float currCurlDown = smr.GetBlendShapeWeight(0);
        float temp;

        var t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / timeToMove;
            temp = Mathf.Lerp(currCurlDown, newCurlDown, t);
            smr.SetBlendShapeWeight(0, temp);
            yield return null;
        }
        bai.changes--;
    }

    private void rotateToYRotation(float newYRot, float timeToMove)
    {
        bai.changes++;
        StartCoroutine(RotateToYRotationI(newYRot, timeToMove));
    }

    private IEnumerator RotateToYRotationI(float newYRot, float timeToMove)
    {
        Vector3 currRotation = transform.localRotation.eulerAngles;
        Vector3 targetRotation = Quaternion.Euler(currRotation.x, newYRot, currRotation.z).eulerAngles;
        Vector3 temp;
        
        var t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / timeToMove;
            temp = Vector3.Lerp(currRotation, targetRotation, t);
            transform.rotation = Quaternion.Euler(temp.x, temp.y, temp.z);
            yield return null;
        }
        bai.changes--;
    }
}