using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public Vector3[] lugares = new Vector3[3];
    Evento activeEvent;
    [SerializeField]List<Evento> eventos = new List<Evento>();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        activeEvent = eventos[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void selectNextEvent()
    {
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
    }
}
