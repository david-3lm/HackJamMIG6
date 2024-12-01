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
    public TimerBar timerBar;
    [SerializeField] private TextMeshProUGUI preguntas;
    
    [Header("Pilotos")]
    [SerializeField] private SpriteRenderer gente;
    [SerializeField] private SpriteRenderer cultura;
    [SerializeField] private SpriteRenderer tren;
    public delegate void ValoresCambiados();
    public event ValoresCambiados OnValoresCambiados;
    public delegate void CheckBlinking(int a, int b);
    public event CheckBlinking OnCheckBlinking;


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
        if (roundCounter >= 10)
        {
            Debug.Log("Fin del juego");
            loadScene.selectScene(2);
        }
        activeEvent = eventos[Random.Range(0, eventos.Count)];
        preguntas.text = activeEvent.pregunta;
    }

    public void removeEvent(Evento evento)
    {
        eventos.Remove(evento);
    }

    private void ActualizarPilotos()
    {
        if (medias[0].x < 40)
            gente.color = Color.red;
        else if (medias[0].x < 60)
            gente.color = Color.yellow;
        else if (medias[0].x < 80)
            gente.color = Color.green;
        if (medias[0].y < 40)
            cultura.color = Color.red;
        else if (medias[0].y < 60)
            cultura.color = Color.yellow;
        else if (medias[0].y < 80)
            cultura.color = Color.green;
        if (medias[0].z < 40)
            tren.color = Color.red;
        else if (medias[0].z < 60)
            tren.color = Color.yellow;
        else if (medias[0].z < 80)
            tren.color = Color.green;
    }
    public void BotonPulsado(bool respuesta)
    {
        CambiarValores(activeEvent.respuestas, respuesta);
        Debug.Log("Boton pulsado: " + respuesta);
        timerBar.resetTimer();
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
        checkGameOver();
        ActualizarPilotos();
    }

    public bool checkGameOver()
    {
        medias[0].x = (lugares[0].x + lugares[0].y + lugares[0].z) / 3;
        medias[0].y = (lugares[1].x + lugares[1].y + lugares[1].z) / 3;
        medias[0].z = (lugares[2].x + lugares[2].y + lugares[2].z) / 3;
        if (medias[0].x <= 20)
            loadScene.selectScene(3);
        else if (medias[0].y <= 20)
            loadScene.selectScene(4);
        else if (medias[0].z <= 20)
            loadScene.selectScene(5);
        if (lugares[0].x <= 30 && lugares[1].x <= 30 && lugares[2].x <= 30)
            loadScene.selectScene(6);
        if (lugares[0].y <= 30 && lugares[1].y <= 30 && lugares[2].y <= 30)
            loadScene.selectScene(6);
        if (lugares[0].z <= 30 && lugares[1].z <= 30 && lugares[2].z <= 30)
            loadScene.selectScene(6);
        return false;
    }

    public void CheckHover()
    {
        for (int i = 0; i < lugares.Length; i++)
        {
            OnCheckBlinking(i, 0);
            OnCheckBlinking(i, 1);
            OnCheckBlinking(i, 2);
        }
    }
    
    public void ResetHover()
    {
       OnCheckBlinking(3, 3);
    }
}
