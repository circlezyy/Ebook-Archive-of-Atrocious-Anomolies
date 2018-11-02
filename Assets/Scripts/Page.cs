using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page : MonoBehaviour
{
    public BookAI bai;

    public void Start()
    {
        bai = transform.GetComponentInParent<BookAI>();
    }

    public void FlipLeft(float rate)
    {
        rotateToYRotation(169f, 1 * rate);
        blendCurlDown(0, 1 * rate);
        spineCurlUp(65, 1 * rate);
    }

    public void FlipRight(float rate)
    {
        rotateToYRotation(11f, 1 * rate);
        blendCurlDown(65, 1 * rate);
        spineCurlUp(0, 1 * rate);
    }

    public void setPosition(Vector3 newPos)
    {
        transform.position = newPos;
    }

    public void setCurlUp(float newCurlUp)
    {
        transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, newCurlUp);

    }

    public void setYRotation(float newYRot)
    {
        transform.eulerAngles = new Vector3(transform.rotation.x,
                                            newYRot,
                                            transform.rotation.z);
    }

    public void setXScale(float newXScale)
    {
        transform.localScale = new Vector3(newXScale,
                                           transform.rotation.y,
                                           transform.rotation.z);
    }

    public void moveZPosition(float zChange, float timeToMove)
    {
        bai.changes++;
        StartCoroutine(moveZPositionI(zChange, timeToMove));
    }

    IEnumerator moveZPositionI(float zChange, float timeToMove)
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

    public void pageCurlDown(float newCurlDown, float timeToMove)
    {
        bai.changes++;
        StartCoroutine(PageCurlDownI(newCurlDown, timeToMove));
    }

    public void pageCurlDown(float timeToWait, float newCurlDown, float timeToMove)
    {
        bai.changes++;
        StartCoroutine(PageCurlDownI(timeToWait, newCurlDown, timeToMove));
    }

    IEnumerator PageCurlDownI(float newCurlDown, float timeToMove)
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

    IEnumerator PageCurlDownI(float timeToWait, float newCurlDown, float timeToMove)
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

    public void pageCurlUp(float newCurlUp, float timeToMove)
    {
        bai.changes++;
        StartCoroutine(PageCurlUpI(newCurlUp, timeToMove));
    }

    public void pageCurlUp(float timeToWait, float newCurlUp, float timeToMove)
    {
        bai.changes++;
        StartCoroutine(PageCurlUpI(timeToWait, newCurlUp, timeToMove));
    }

    IEnumerator PageCurlUpI(float timeToWait, float newCurlUp, float timeToMove)
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

    IEnumerator PageCurlUpI(float newCurlUp, float timeToMove)
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

    public void spineCurlUp(float newCurlUp, float timeToMove)
    {
        bai.changes++;
        StartCoroutine(SpineCurlUpI(newCurlUp, timeToMove));
    }

    IEnumerator SpineCurlUpI(float newCurlUp, float timeToMove)
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

    public void blendCurlDown(float newCurlDown, float timeToMove)
    {
        bai.changes++;
        StartCoroutine(BlendCurlDownI(newCurlDown, timeToMove));
    }

    IEnumerator BlendCurlDownI(float newCurlDown, float timeToMove)
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

    public void rotateToYRotation(float newYRot, float timeToMove)
    {
        bai.changes++;
        StartCoroutine(RotateToYRotationI(newYRot, timeToMove));
    }

    IEnumerator RotateToYRotationI(float newYRot, float timeToMove)
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