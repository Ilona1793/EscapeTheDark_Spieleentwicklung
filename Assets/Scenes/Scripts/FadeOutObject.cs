using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutObject : MonoBehaviour
{
    [SerializeField]
    private float alphaValue = 0.5f;

    private bool isFadingOut = false;
    private bool isFadingIn = false;

    private float lastTimeCalled = 0f;

    private MeshRenderer meshRenderer;

    private void Start()
    {
         meshRenderer = this.GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (lastTimeCalled > 1f && !isFadingIn)
        {
            FadeIn();
        } else if(lastTimeCalled < 1f)
        {
            lastTimeCalled += Time.deltaTime;
        }
    }

    private void FadeIn()
    {
        if (!isFadingIn)
        {
            changeAlphaValue(1f);
            isFadingIn = true;
            isFadingOut = false;
        }
    }

    private void changeAlphaValue(float alphaValue)
    {
        Color colorStart = meshRenderer.material.color;
        colorStart.a = alphaValue;
        meshRenderer.material.color = colorStart;
    }

    /// <summary>
    /// 
    /// </summary>
    public void FadeOut()
    {
        if (!isFadingOut)
        {
            changeAlphaValue(alphaValue);
            isFadingOut = true;
            isFadingIn = false;
        }
        lastTimeCalled = 0f;
    }
}
