using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnimationManager : MonoBehaviour
{
    #region SINGLETON DECLARATION

    private static AnimationManager instance;
    public bool isAnimating { get; private set; }

    public static AnimationManager GetInstance ()
    {
        return instance;
    }

    #endregion

    #region ANIMATION GAMEOBJECTS

    [Header("Day Display")]
    public TMP_Text DayDisplayText;
    [Header("BlackScreen")]
    public Image BlackScreen;

    #endregion

    private void Awake ()
    {
        if (instance != null) {
            Debug.LogWarning("More than one instance of AnimationManager running");
        }

        instance = this;
    }

    #region // ANIMATION METHODS

    public void Clock ()
    {
        StartCoroutine(ClockCoroutine());
    }

    IEnumerator ClockCoroutine ()
    {
        isAnimating = true;

        float time = 0;
        float duration = 2;
        Color textColor = DayDisplayText.color;
        while (time < duration) {
            textColor.a = Mathf.Lerp(0, 1, time / duration);
            DayDisplayText.color = textColor;
            time += Time.deltaTime;
            yield return null;
        }
        textColor.a = 1;
        DayDisplayText.color = textColor;
        isAnimating = false;
    }

    public void FadeToBlack ()
    {
        StartCoroutine(FadeToBlackCoroutine(true));
    }

    public void FadeFromBlack ()
    {
        StartCoroutine(FadeToBlackCoroutine(false));
    }

    IEnumerator FadeToBlackCoroutine(bool toBlack)
    {
        isAnimating = true;

        float time = 0;
        float duration = 3;
        Color currentColor = BlackScreen.color;
        float targetAlpha = toBlack ? 1 : 0;
        float startAlpha = toBlack ? 0 : 1;
        while (time < duration) {
            currentColor.a = Mathf.Lerp(startAlpha, targetAlpha, time / duration);
            BlackScreen.color = currentColor;
            time += Time.deltaTime;
            yield return null;
        }
        currentColor.a = targetAlpha;
        BlackScreen.color = currentColor;
        isAnimating = false;
    }

    #endregion
}
