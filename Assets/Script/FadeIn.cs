using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public Image fade;
    float time;
    public float fades;

    void Update()
    {
        time += Time.deltaTime;
        if (time < fades)
        {
            float r = fade.color.r;
            float g = fade.color.g;
            float b = fade.color.b;
            fade.color = new Color(r, g, b, 0f + time / fades);
        }
        else
        {
            time = 0;
        }

    }
}
