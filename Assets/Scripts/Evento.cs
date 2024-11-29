using UnityEngine;

[CreateAssetMenu(fileName = "Evento", menuName = "Scriptable Objects/Evento")]
public class Evento : ScriptableObject
{
	public int id;
    public string pregunta;
	public Vector3[] respuestas = new Vector3[3];
	public string si;
	public string no; 

	public void pulsadoSi()
	{
		//find gamamanager and call the function
		//CambiarValores(respuestas);
		Debug.Log("Pulsado SI");
	}

	public void pulsadoNo()
	{
		//find gamamanager and call the function
		//CambiarValores(-respuestas);
		Debug.Log("Pulsado NO");
	}
}
