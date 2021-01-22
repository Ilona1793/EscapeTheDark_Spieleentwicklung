using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutPlatform : MonoBehaviour
{
    public float fadeOutTimer = 0f;

    private float fadeOutTimerDelta = 0f;
    private MeshRenderer meshRenderer;

    public int interpolationFramesCount = 45; // Number of frames to completely interpolate between the 2 positions
    int elapsedFrames = 0;

    private bool isFading = false;

    private void Start()
    {
        meshRenderer = this.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeOutTimerDelta > fadeOutTimer)
        {
            isFading = true;
            fadeOutTimerDelta = 0f;

        }
        else
        {
            fadeOutTimerDelta += Time.deltaTime;
        }

        if (isFading)
        {
            float interpolationRatio = (float)elapsedFrames / interpolationFramesCount;

            float interpolatedAlpha = Mathf.Lerp(0.3f, 0f, interpolationRatio);

            elapsedFrames = (elapsedFrames + 1) % (interpolationFramesCount + 1);  // reset elapsedFrames to zero after it reached (interpolationFramesCount + 1)
            FadeOutObject(interpolatedAlpha);
        }
        else
        {
            FadeOutObject(1f);
        }
    }

    private void FadeOutObject(float alphaValue)
    {
        Color colorStart = meshRenderer.material.color;
        colorStart.a = alphaValue;
        meshRenderer.material.color = colorStart;
        if (alphaValue <= 0f)
        {
            isFading = false;
        }
    }
}
