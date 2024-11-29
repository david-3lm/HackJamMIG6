using System.IO;
using UnityEditor;
using UnityEngine;

public class EventoImporter : MonoBehaviour
{
    public string csvFileName = "eventos.csv"; // Nombre del archivo CSV en la carpeta Resources

    public void ImportCSV()
    {
        // Ruta del archivo en Resources
        string filePath = Path.Combine(Application.dataPath, "Resources", csvFileName);

        if (!File.Exists(filePath))
        {
            Debug.LogError($"El archivo {csvFileName} no se encontró en la ruta: {filePath}");
            return;
        }

        // Leer todas las líneas del archivo
        string[] lines = File.ReadAllLines(filePath);

        // Saltar la primera línea (encabezados)
        for (int i = 1; i < lines.Length; i++)
        {
            string[] data = lines[i].Split(',');

            // Crear un nuevo ScriptableObject
            Evento evento = ScriptableObject.CreateInstance<Evento>();

            // Asignar valores del CSV a las variables del Evento
            evento.id = int.Parse(data[0]);
            evento.pregunta = data[1];
            evento.respuestas[0] = new Vector3(float.Parse(data[2]), float.Parse(data[3]), float.Parse(data[4]));
            evento.respuestas[1] = new Vector3(float.Parse(data[5]), float.Parse(data[6]), float.Parse(data[7]));
            evento.respuestas[2] = new Vector3(float.Parse(data[8]), float.Parse(data[9]), float.Parse(data[10]));
            evento.si = data[11];
            evento.no = data[12];

            // Guardar el ScriptableObject como un archivo
            SaveEvento(evento, $"Evento_{evento.id}");
        }
    }

    private void SaveEvento(Evento evento, string assetName)
    {
        // Guardar el ScriptableObject en la carpeta Assets
        string path = $"Assets/ScriptableObjects/{assetName}.asset";

        // Asegurarse de que la carpeta exista
        Directory.CreateDirectory(Path.GetDirectoryName(path));

        AssetDatabase.CreateAsset(evento, path);
        AssetDatabase.SaveAssets();

        Debug.Log($"Evento guardado: {path}");
    }
}
