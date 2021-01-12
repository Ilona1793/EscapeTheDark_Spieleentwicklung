using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutObject : MonoBehaviour
{
    private bool isFadingOut = false;

    /// <summary>
    /// 
    /// </summary>
    public void FadeOut()
    {
        //TODO: really do a fade out...
        if (!isFadingOut)
        {
            MeshRenderer meshRenderer = this.GetComponent<MeshRenderer>();
            Color colorStart = meshRenderer.material.color;
            colorStart.a = 0f;
            meshRenderer.material.color = colorStart;
            isFadingOut = true;
        }

    }
}
