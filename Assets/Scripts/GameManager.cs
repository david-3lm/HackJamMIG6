using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Vector3[] lugares = new Vector3[3];
    public Vector3[] medias = new Vector3[1];
    public Evento activeEvent;
    [SerializeField]List<Evento> eventos = new List<Evento>();
    int roundCounter = 1;
    public LoadScene loadScene;
    [SerializeField] private TextMeshProUGUI preguntas;
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
        preguntas.text = activeEvent.pregunta;
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
        medias[0].x = (lugares[0].x + lugares[0].y + lugares[0].z) / 3;
        medias[0].y = (lugares[1].x + lugares[1].y + lugares[1].z) / 3;
        medias[0].z = (lugares[2].x + lugares[2].y + lugares[2].z) / 3;
        if (medias[0].x < 30 || medias[0].y < 30 || medias[0].z < 30)
            return true;
        if (lugares[0].x <= 30 && lugares[1].x <= 30 && lugares[2].x <= 30)
            return true;
        if (lugares[0].y <= 30 && lugares[1].y <= 30 && lugares[2].y <= 30)
            return true;
        if (lugares[0].z <= 30 && lugares[1].z <= 30 && lugares[2].z <= 30)
            return true;
        return false;
    }
}
