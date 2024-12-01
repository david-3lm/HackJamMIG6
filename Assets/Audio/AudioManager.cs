using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    private void Awake()
    {
        // Comprobar si ya existe una instancia del AudioManager
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // Destruir la nueva instancia
            return;
        }

        // Hacer que este objeto persista entre escenas
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Métodos para controlar el audio
    public void PlaySound(AudioClip clip, float volume = 1f)
    {
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, volume);
    }
}
