using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public Vector3[] lugares = new Vector3[3];
    public Vector3[] medias = new Vector3[2];
    public Evento activeEvent;
    [SerializeField]List<Evento> eventos = new List<Evento>();
    int roundCounter = 1;
    public LoadScene loadScene;
    
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
            loadScene.winGame();
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
        if (checkGameOver())
            loadScene.loseGame();
    }

    public bool checkGameOver()
    {
        Debug.Log("Checking game over");
        for (int i = 0; i < lugares.Length; i++)
        {
            if (lugares[i].x <= 30 && lugares[i].y <= 30 && lugares[i].z <= 30)
                return true;
        }
        return false;
    }
}
