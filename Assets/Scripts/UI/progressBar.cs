using System.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

//[ExecuteInEditMode()]
public class progressBar : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image mask;
    [SerializeField] private float max = 100f;
    [SerializeField] private float cur = 0f;
    [SerializeField] private float drainRate = 14.5f;

    void Start()
    {

    }

    private void Update()
    {
        cur -= drainRate * Time.deltaTime; //decreases by the drainRate/per second
        cur = Mathf.Clamp(cur, 0, max);

        UpdateBar();
    }

    private void UpdateBar()
    {
        float fillAmount = cur / max;
        mask.fillAmount = fillAmount;
    }

    public void SetValue(float value)
    {
        cur = Mathf.Clamp(value, 0, max);
        UpdateBar();
    }
}
