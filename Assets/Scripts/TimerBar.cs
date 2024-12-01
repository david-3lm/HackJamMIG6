using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerBar : MonoBehaviour
{
    public Image fillImage;
    public float duration = 10;
    public LoadScene loadScene;

    private float timeRemaining;
    private Color startColor = new Color(1f, 1f, 1f, 0.2f);
    private Color endColor = Color.red;
    private bool isFlashing = false;

    void Start()
    {
        timeRemaining = duration;
        fillImage.fillAmount = 1;
        fillImage.color = startColor;
    }

    public void resetTimer()
    {
        timeRemaining = duration;
        fillImage.fillAmount = 1;
        fillImage.color = startColor;
        StopAllCoroutines();
        isFlashing = false;
        fillImage.enabled = true;
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;

            fillImage.fillAmount = timeRemaining / duration;

            fillImage.color = Color.Lerp(startColor, endColor, 1 - fillImage.fillAmount);

            if (timeRemaining <= 4 && !isFlashing)
            {
                isFlashing = true;
                StartCoroutine(FlashFill());
            }
        }
        else
        {
            StopAllCoroutines();
            fillImage.fillAmount = 0;
            loadScene.selectScene(7);
        }
    }

    private IEnumerator FlashFill()
    {
        while (true)
        {
            fillImage.enabled = !fillImage.enabled;
            yield return new WaitForSeconds(0.4f);
        }
    }
}
