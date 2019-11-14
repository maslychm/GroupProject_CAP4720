using System;
using UnityEngine;
using UnityEngine.UI;

public class FPSTotalCounter : MonoBehaviour
{
    private int m_FpsAccumulator = 0;
    const string display = "{0} total";
    private Text m_Text;
    public int target = 60;

    private void Start()
    {
        // Lock the framerate
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = target;

        m_Text = GetComponent<Text>();
    }

    private void Update()
    {
        if (Application.targetFrameRate != target)
        {
            Application.targetFrameRate = target;
        }

        m_FpsAccumulator++;
        m_Text.text = string.Format(display, m_FpsAccumulator);
    }
}
