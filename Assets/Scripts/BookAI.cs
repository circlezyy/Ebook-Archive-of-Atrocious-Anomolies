using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookAI : MonoBehaviour
{
    public BookStateMachine StateMachine { get; set; }
    public UserInput ui;

    public Page fc; //front cover
    public Page p1;
    public Page p2;
    public Page p3;
    public Page p4;
    public Page p5;
    public Page p6;
    public Page p7;
    public Page p8;
    public Page p9;
    public Page bc; //back cover
    
    private void Start()
    {
        StateMachine = new BookStateMachine(this.gameObject);
        StateMachine.Initialize();
    }

    private void Update()
    {
        StateMachine.Update();
    }
}
