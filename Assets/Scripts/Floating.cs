using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Floating : MonoBehaviour
{
    public GameObject zelda;
    public GameObject girl;
    public GameObject metroid;
    public BookAI bai;

    public Slider slider;

    public GameObject[] interactables;

    public GameObject[] buttonGroups;


    void Start()
    {
        disableAll();
    }

    void disableAll()
    {
        //disable buttons
        foreach (GameObject child in buttonGroups)
        {
            child.SetActive(false);
        }

        //make interactables transparent
        foreach (GameObject child in interactables)
        {
            foreach (Transform grandchild in child.transform)
            {
                Color tmp = grandchild.GetComponent<SpriteRenderer>().color;
                tmp.a = 0;
                grandchild.GetComponent<SpriteRenderer>().color = tmp;
            }
        }
    }

    public void ToggleAnimation(string name)
    {
        switch(name)
        {
            case "Girl":
                girl.GetComponent<Animator>().enabled = !girl.GetComponent<Animator>().isActiveAndEnabled;
                break;
            case "Zelda":
                zelda.GetComponent<Animator>().enabled = !zelda.GetComponent<Animator>().isActiveAndEnabled;
                break;
            case "Metroid":
                metroid.GetComponent<Animator>().enabled = !metroid.GetComponent<Animator>().isActiveAndEnabled;
                break;
            default:
                break;
        }
    }

    public void hideInteractables(int currPage)
    {
        switch(currPage)
        {
            case 1:
                buttonGroups[0].SetActive(false);

                foreach (Transform child in interactables[0].transform)
                {
                    Color tmp = child.GetComponent<SpriteRenderer>().color;
                    tmp.a = 0;
                    child.GetComponent<SpriteRenderer>().color = tmp;
                }
                break;
            case 2:
                buttonGroups[1].SetActive(false);

                foreach (Transform child in interactables[1].transform)
                {
                    Color tmp = child.GetComponent<SpriteRenderer>().color;
                    tmp.a = 0;
                    child.GetComponent<SpriteRenderer>().color = tmp;
                }
                break;
            default:
                break;
        }

    }

    public void revealInteractables(int currPage)
    {
        switch (currPage)
        {
            case 1:
                buttonGroups[0].SetActive(true);

                foreach (Transform child in interactables[0].transform)
                {
                    Color tmp = child.GetComponent<SpriteRenderer>().color;
                    tmp.a = 1;
                    child.GetComponent<SpriteRenderer>().color = tmp;
                }
                break;
            case 2:
                buttonGroups[1].SetActive(true);

                foreach (Transform child in interactables[1].transform)
                {
                    Color tmp = child.GetComponent<SpriteRenderer>().color;
                    tmp.a = 1;
                    child.GetComponent<SpriteRenderer>().color = tmp;
                }
                break;
            default:
                break;
        }
    }
}
