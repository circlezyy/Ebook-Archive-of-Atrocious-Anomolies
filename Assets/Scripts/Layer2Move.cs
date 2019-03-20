using System.Collections;
using UnityEngine;

public class Layer2Move : MonoBehaviour
{
    public Transform startTransform;
    public Transform endTransform;
    public float speed = 1;
    private float maxDistance;

    private RectTransform rt;
    private CanvasGroup cg;

    private void OnEnable()
    {
        transform.position = startTransform.position;
        maxDistance = Vector3.Distance(startTransform.position, endTransform.position);
        cg = GetComponent<CanvasGroup>();
        rt = GetComponent<RectTransform>();
        cg.alpha = 0;
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        while(Vector3.Distance(transform.position, endTransform.position) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, endTransform.position, Time.deltaTime * speed);
            float fraction = 1 - Vector3.Distance(transform.position, endTransform.position) / maxDistance;
            cg.alpha = fraction;
            rt.localScale = new Vector3(fraction, fraction, 1);
            yield return null;
        }
        transform.position = endTransform.position;
        cg.alpha = 1;
        rt.localScale = Vector3.one;
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
