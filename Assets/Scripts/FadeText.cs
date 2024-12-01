using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextSequence : MonoBehaviour
{
    public TMP_Text[] texts;
    public float fadeDuration = 1f;
    public float displayDuration = 2f;

    void Start()
    {
        StartCoroutine(ShowTextSequence());
    }

    IEnumerator ShowTextSequence()
    {
        foreach (TMP_Text text in texts)
        {
            yield return StartCoroutine(FadeIn(text));
            yield return new WaitForSeconds(displayDuration);
            yield return StartCoroutine(FadeOut(text));
        }
        Debug.Log("Secuencia de textos completada");
    }

    IEnumerator FadeIn(TMP_Text text)
    {
        text.gameObject.SetActive(true);
        Color color = text.color;
        color.a = 0f;
        text.color = color;

        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            color.a = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            text.color = color;
            yield return null;
        }

        color.a = 1f;
        text.color = color;
    }

    IEnumerator FadeOut(TMP_Text text)
    {
        Color color = text.color;
        color.a = 1f;
        text.color = color;

        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            color.a = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            text.color = color;
            yield return null;
        }

        color.a = 0f;
        text.color = color;
        text.gameObject.SetActive(false);
    }
}
