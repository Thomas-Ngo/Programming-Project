using System.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class progressBar : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image mask;   // UI Image reference
    [SerializeField] private float max = 100f;
    [SerializeField] private float cur = 0f;

    void Start()
    {

    }

    void Update()
    {
        UpdateBar();
    }

    private void UpdateBar()
    {
        float fillamt = cur / max;
        mask.fillAmount = fillamt;
    }

    public void SetValue(float value)
    {
        cur = Mathf.Clamp(value, 0, max);
        UpdateBar();
    }
}
