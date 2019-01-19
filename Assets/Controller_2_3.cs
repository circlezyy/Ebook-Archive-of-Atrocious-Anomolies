using UnityEngine;
using UnityEngine.EventSystems;

public class Controller_2_3 : MonoBehaviour
{
    public void ButtonClicked(string name)
    {
        Debug.Log(EventSystem.current.currentSelectedGameObject.name);
    }
}
