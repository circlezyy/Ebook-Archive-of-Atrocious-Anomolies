using UnityEngine;
using System;

public class MaterialImageVideo : MonoBehaviour
{
    public Material material;
    public Sprite[] sprites;
    public float fps = 24;
    private float rate = 0;

    private int frameNum = 0;

    private void Start()
    {
        rate = 1 / fps;
        DoSortFrames();
        InvokeRepeating("ChangeSprite", 0, rate);
    }

    void DoSortFrames()
    {
        Array.Sort(sprites, (a, b) => string.Compare(a.name, b.name, StringComparison.Ordinal));
    }

    private void OnDisable()
    {
        CancelInvoke("ChangeSprite");
    }

    private void OnEnable()
    {
        InvokeRepeating("ChangeSprite", 0, rate);
    }

    private void ChangeSprite()
    {
        material.mainTexture = sprites[frameNum++].texture;
        if (frameNum > sprites.Length - 1)
        {
            frameNum = 0;
        }
    }




}
