using UnityEngine;

public class Cursor : MonoBehaviour
{
    public GameObject cursor;
    private Animator animator;

    void Start()
    {
        animator = cursor.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            cursor.GetComponent<RectTransform>().position = Input.mousePosition;
            animator.Play("Tap", -1, 0);
        }
    }
}
