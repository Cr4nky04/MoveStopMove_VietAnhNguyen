using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTransparent : MonoBehaviour
{
    public Player player;
    Material mat;
    private float originalOpacity;
    public bool DoFade = false;
    public float fadeAmount;
    public float fadeSpeed;

    private void Start()
    {
        mat = GetComponent<Renderer>().material;
        originalOpacity = mat.color.a;
    }

    private void Update()
    {
        if(DoFade)
        {
            FadeNow();
            Debug.Log("Fade");
        }
        else
        {
            ResetFade();
        }
    }

    private void ResetFade()
    {
        Color currentColor = mat.color;
        Color smoothColor = new Color(currentColor.r, currentColor.g, currentColor.b, Mathf.Lerp(currentColor.a, originalOpacity, fadeSpeed * Time.deltaTime)); 
        mat.color = smoothColor;
    }

    private void FadeNow()
    {
        Color currentColor = mat.color;
        Color smoothColor = new Color(currentColor.r, currentColor.g, currentColor.b, Mathf.Lerp(currentColor.a, fadeAmount, fadeSpeed * Time.deltaTime));
        mat.color = smoothColor;
    }
}
