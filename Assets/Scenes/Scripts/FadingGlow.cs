using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingGlow : MonoBehaviour
{
    public Material mat;
    public Color col;

    public float intensityMax = 255;
    public float _intensity = 255;
    public float decrease = 1;
    public float offTimer;
    private bool isOn = true;
    private float t = 0f;
    private float offTimerDelta = 0f;
    private Material copied;
    public MeshCollider meshCollider;

    void Start()
    {
        copied = new Material(mat);
        GetComponent<MeshRenderer>().material = copied;

        meshCollider = this.GetComponent<MeshCollider>();
        meshCollider.enabled = false;
    }

    void Update()
    {
        if (isOn)
        {
            meshCollider.enabled = true;
            copied.SetVector("_EmissionColor", col * _intensity);
            _intensity = _intensity - decrease;
            if (_intensity < 0)
            {
                isOn = false;
                _intensity = intensityMax;
                
            }
        } else
        {
            if(offTimer < offTimerDelta)
            {
                isOn = true;
                offTimerDelta = 0f;
                copied.color = new Vector4(col.r, col.g, col.b, 1f);
                t = 0f;
                

            }
            else
            {
                Debug.Log("Off:"+ offTimer);
                Debug.Log("Off-Delta:" + offTimerDelta);
                offTimerDelta += Time.deltaTime;
                FadeOutAlpha();
              
            }
           
            
        }
    }

    public void FadeOutAlpha()
    {
        if(t > 2f)
        {
            return;
        }
        float alpha = Mathf.Lerp(1f, 0f, t);

        t += 1*  Time.deltaTime;

        copied.color = new Vector4(col.r, col.g, col.b, alpha);

        meshCollider.enabled = false;
        
    }
}
