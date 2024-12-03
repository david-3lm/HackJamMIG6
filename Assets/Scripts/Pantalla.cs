using System;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.Rendering;

public class Pantalla : MonoBehaviour
{
    [SerializeField] private int x;
    [SerializeField] private int y;
    [SerializeField] SpriteRenderer imagen;
    [SerializeField] List<Sprite> imagenes;

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
        material = new Material(sr.material);
        sr.material = material;
        material = sr.material;
        gm.OnValoresCambiados += ActualizarValores;
        gm.OnBlinkea += StartBlink;
        imagen.sprite = imagenes[1];
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
            material.color = new Color(1, 0, 0.5f, value);
            imagen.sprite = imagenes[0];
            //Debug.Log("Camara Roja en posicion" + x + y);
        }
        else if (value >= 40 && value <= 70)
        {
            //camara naranja
            material.color = new Color(1, 1.0f, 0.2f, value);
            imagen.sprite = imagenes[1];
            //Debug.Log("Camara Naranja en posicion" + x + y);
        }
        else if (value >= 70)
        {
            //camara verde  
            material.color = new Color(0, 1, 0, value);
            imagen.sprite = imagenes[2];
            //Debug.Log("Camara verde en posicion " + x + y);
        }
    }

    void StartBlink(int a, int b)
    {
        if (a == x && b == y)
        {
            material.SetFloat("_Blink", 1f);
            Debug.Log("Soy la pantalla " + x + " " + y + " y empiezo a blinkear");
        }
        else if (a == -1 && b == -1)
        {
            material.SetFloat("_Blink", 0f);
            Debug.Log("Soy la pantalla " + x + " " + y + " y dejo de blinkear");
        }
    }
}
