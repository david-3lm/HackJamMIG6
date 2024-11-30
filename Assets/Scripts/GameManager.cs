using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Vector3[] lugares = new Vector3[3];
    public Vector3[] medias = new Vector3[2];
    Evento activeEvent;
    [SerializeField]List<Evento> eventos = new List<Evento>();
    int roundCounter = 1;
    
    public delegate void ValoresCambiados();
    public event ValoresCambiados OnValoresCambiados;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        selectNextEvent();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void selectNextEvent()
    {
        roundCounter++;
        if (roundCounter >= 15)
        {
            Debug.Log("Fin del juego");
            winGame();
        }
        activeEvent = eventos[Random.Range(0, eventos.Count)];
    }

    public void removeEvent(Evento evento)
    {
        eventos.Remove(evento);
    }

    public void BotonPulsado(bool respuesta)
    {
        CambiarValores(activeEvent.respuestas, respuesta);
        Debug.Log("Boton pulsado: " + respuesta);
        selectNextEvent();
        removeEvent(activeEvent);
    }

    public void CambiarValores(Vector3[] valores, bool respuesta)
    {
        for (int i = 0; i < valores.Length; i++)
        {
            if (respuesta)
                lugares[i] += valores[i];
            else
                lugares[i] += (-1 * valores[i]);
        }

        if (OnValoresCambiados != null)
            OnValoresCambiados();
        setCamColor();
        makeAverage();
    }

    public void setCamColor()
    {
        //esta funcion es una mierda porque se me hace
        //demasiado grande pero para ir camara por camara
        //no se como hacerlo sino
        for (int i = 0; i < lugares.Length; i++)
        {
            if (lugares[i].x <= 30)
            {
                //camara roja
            }
            else if (lugares[i].x >= 40 && lugares[i].x <= 70)
            {
                //camara naranja
            }
            else if (lugares[i].x <= 70)
            {
                //camara verde
            }
            
            if (lugares[i].y <= 30)
            {
                //camara roja
            }
            else if (lugares[i].y >= 40 && lugares[i].y <= 70)
            {
                //camara naranja
            }
            else if (lugares[i].y <= 70)
            {
                //camara verde
            }


            if (lugares[i].z <= 30)
            {
                //camara roja
            }
            else if (lugares[i].z >= 40 && lugares[i].z <= 70)
            {
                //camara naranja
            }
            else if (lugares[i].z <= 70)
            {
                //camara verde
            }
        }
    }

    public void makeAverage()
    {
        //hacer media ponderada de cada fila y columna
        //he pensado en crear 6 variables para cada media
        //las 3 de horizontal y las 3 de vertical
        //porque el vector 3 ya no nos da mas valores
        
    }

    public void winGame()
    {
        //la escena de win game no tiene nada aun
        //habria que meterle algo visual y un volver al menu
        //o algo asi, o acabar ahi y ya si no nos da tiempo
        Debug.Log("Fin del juego");
        SceneManager.LoadScene("WinGame");
    }
}
