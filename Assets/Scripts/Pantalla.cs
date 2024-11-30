using System;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.Rendering;

public class Pantalla : MonoBehaviour
{
    [SerializeField] private int x;
    [SerializeField] private int y;

    private GameManager gm;

    private SpriteRenderer sr;
    Material material;

    public float value;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gm = FindFirstObjectByType<GameManager>();
        value = gm.lugares[x][y];
        sr = GetComponent<SpriteRenderer>();
        material = sr.material;
        gm.OnValoresCambiados += ActualizarValores;
        ActualizarColor();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ActualizarValores()
    {
        value = gm.lugares[x][y];
        ActualizarColor();
    }

    void ActualizarColor()
    {
        if (value <= 30)
        {
            //camara roja
            material.color = new Color(1, 0, 0, value);
            //Debug.Log("Camara Roja en posicion" + x + y);
        }
        else if (value >= 40 && value <= 70)
        {
            //camara naranja
            material.color = new Color(1, 1.0f, 0.5f, value);
            //Debug.Log("Camara Naranja en posicion" + x + y);
        }
        else if (value >= 70)
        {
            //camara verde  
            material.color = new Color(0, 1, 0, value);
            //Debug.Log("Camara verde en posicion " + x + y);
        }
    }
}
