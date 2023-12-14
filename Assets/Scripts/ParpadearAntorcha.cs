using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ParpadearAntorcha : MonoBehaviour
{
    public Light2D luzAntorcha;
    public float intensidadMinima = 0.5f;
    public float intensidadMaxima = 1.0f;
    public float velocidadParpadeo = 2.0f;

    private void Start()
    {
    }

    private void Update()
    {
        float intensidadParpadeo = Mathf.Lerp(intensidadMinima, intensidadMaxima, Mathf.PingPong(Time.time * velocidadParpadeo, 1.0f));


        luzAntorcha.intensity = intensidadParpadeo;
    }
}
