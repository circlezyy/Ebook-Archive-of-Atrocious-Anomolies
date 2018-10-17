using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CurlDirection
{
    Up, Down
}

public class Page : MonoBehaviour
{
    public int changes = 0;

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
        StartCoroutine(moveZPositionI(zChange, timeToMove));
    }

    public IEnumerator moveZPositionI(float zChange, float timeToMove)
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
    }

    public void blendCurlDown(float newCurlDown, float curlRate)
    {
        changes++;
        StartCoroutine(BlendCurlDownI(newCurlDown, curlRate));
    }

    public void blendCurlUp(float newCurlUp, float curlRate)
    {
        changes++;
        StartCoroutine(BlendCurlUpI(newCurlUp, curlRate));
    }

    IEnumerator BlendCurlUpI(float newCurlUp, float curlRate)
    {
        SkinnedMeshRenderer smr = transform.GetChild(0).GetComponent<SkinnedMeshRenderer>();
        float currCurlUp = smr.GetBlendShapeWeight(1);

        if (currCurlUp < newCurlUp)
        {
            while (currCurlUp < newCurlUp)
            {
                currCurlUp += curlRate * Time.deltaTime;

                if (currCurlUp >= newCurlUp)
                    break;

                smr.SetBlendShapeWeight(1, currCurlUp);

                yield return null;
            }
        }
        else
        {
            while (currCurlUp > newCurlUp)
            {
                currCurlUp -= curlRate * Time.deltaTime;

                if (currCurlUp <= newCurlUp)
                    break;

                smr.SetBlendShapeWeight(1, currCurlUp);

                yield return null;
            }

        }


        smr.SetBlendShapeWeight(1, newCurlUp);
        changes--;
    }

    IEnumerator BlendCurlDownI(float newCurlDown, float curlRate)
    {
        SkinnedMeshRenderer smr = transform.GetChild(0).GetComponent<SkinnedMeshRenderer>();
        float currCurlDown = smr.GetBlendShapeWeight(0);

        if (currCurlDown < newCurlDown)
        {
            while (currCurlDown < newCurlDown)
            {
                currCurlDown += curlRate * Time.deltaTime;

                if (currCurlDown >= newCurlDown)
                    break;

                smr.SetBlendShapeWeight(0, currCurlDown);

                yield return null;
            }
        }
        else
        {
            while (currCurlDown > newCurlDown)
            {
                currCurlDown -= curlRate * Time.deltaTime;

                if (currCurlDown <= newCurlDown)
                    break;

                smr.SetBlendShapeWeight(0, currCurlDown);

                yield return null;
            }

        }


        smr.SetBlendShapeWeight(0, newCurlDown);
        changes--;
    }

    public void rotateToYRotation(float newYRot, float rotateRate)
    {
        changes++;

        if (newYRot > transform.localRotation.eulerAngles.y)
            StartCoroutine(RotateToHigherYRotationI(newYRot, rotateRate));
        else
        {
            StartCoroutine(RotateToLowerYRotationI(newYRot, rotateRate));
        }

    }

    IEnumerator RotateToLowerYRotationI(float newYRot, float rotateRate)
    {
        float currRotation = transform.localRotation.eulerAngles.y;

        Debug.Log(currRotation + ", " + newYRot);

        while (currRotation > newYRot)
        {
            currRotation -= rotateRate * Time.deltaTime;

            if (currRotation <= newYRot)
                break;

            transform.rotation = Quaternion.Euler(transform.rotation.x,
                                                  currRotation,
                                                  transform.rotation.z);
            yield return null;
        }
        transform.rotation = Quaternion.Euler(0, newYRot, 0);
        changes--;
    }

    IEnumerator RotateToHigherYRotationI(float newYRot, float rotateRate)
    {
        float currRotation = transform.localRotation.eulerAngles.y;

        while (currRotation < newYRot)
        {
            currRotation += rotateRate * Time.deltaTime;
            if (currRotation >= newYRot)
                break;

            transform.rotation = Quaternion.Euler(transform.rotation.x,
                                                  currRotation,
                                                  transform.rotation.z);
            yield return null;
        }
        transform.rotation = Quaternion.Euler(0, newYRot, 0);
        changes--;
    }
}