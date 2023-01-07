using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class AnimationManager : MonoBehaviour
{
    #region SINGLETON DECLARATION

    private static AnimationManager instance;
    public bool isAnimating { get; private set; }

    public static AnimationManager GetInstance () { return instance; }

    #endregion

    #region ANIMATION GAMEOBJECTS

    [Header("Day Display")]
    public TMP_Text DayDisplayText;
    [Header("Black Screen")]
    public Image BlackScreen;
    [Header("Coffee Mug")]
    public Transform LiquidPosition;
    [Header("Desk")]
    public Transform DeskPosition;
    public float zPosDesk;
    [Header("Armoire")]
    public Transform ArmoireDoorPosition;
    public float xPosArmoireOpen;
    public float xPosArmoireClose;
    [Header("BlackestVoid")]
    public AudioSource BlackestVoidAudioSource;
    [Header("Dressing")]
    public Animator DressingAnimator;
    [Header("DoorBed")]
    public Animator DoorBedAnimator;
    public Transform DoorBedPosition;
    public float yPosDoorBed;

    #endregion

    private void Awake ()
    {
        if (instance != null) {
            Debug.LogWarning("More than one instance of AnimationManager running");
        }

        instance = this;
    }

    #region // ANIMATION METHODS

    public void Clock () { StartCoroutine(ClockCoroutine()); }
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

    public void FadeToBlack () { StartCoroutine(FadeToBlackCoroutine(true)); }
    public void FadeFromBlack () { StartCoroutine(FadeToBlackCoroutine(false)); }
    public void FadeFromBlackQuick () { StartCoroutine(FadeToBlackCoroutine(false, 0.2f)); }
    IEnumerator FadeToBlackCoroutine(bool toBlack, float duration = 3)
    {
        isAnimating = true;

        float time = 0;
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

    public void CoffeeDrink () { StartCoroutine(CoffeeDrinkCoroutine()); }
    IEnumerator CoffeeDrinkCoroutine ()
    {
        isAnimating = true;

        float time = 0f;
        float duration = 2f;
        Vector3 currentPosition = LiquidPosition.position;
        Vector3 startPosition = currentPosition;
        Vector3 desiredPosition = currentPosition - Vector3.up * 0.5f;
        while (time < duration) {
            currentPosition = Vector3.Lerp(startPosition, desiredPosition, time / duration);
            LiquidPosition.position = currentPosition;
            time += Time.deltaTime;
            yield return null;
        }
        LiquidPosition.position = desiredPosition;
        LiquidPosition.gameObject.SetActive(false);
        isAnimating = false;
    }

    public void Desk () { StartCoroutine(DeskCoroutine()); }
    IEnumerator DeskCoroutine ()
    {
        isAnimating = true;

        float time = 0f;
        float duration = 2f;
        Vector3 currentPosition = DeskPosition.position;
        Vector3 startPosition = currentPosition;
        Vector3 desiredPosition = new Vector3 (currentPosition.x, currentPosition.y, zPosDesk);
        while (time < duration) {
            currentPosition = Vector3.Lerp(startPosition, desiredPosition, time / duration);
            DeskPosition.position = currentPosition;
            time += Time.deltaTime;
            yield return null;
        }
        DeskPosition.position = desiredPosition;
        DeskPosition.gameObject.SetActive(false);
        isAnimating = false;
    }

    public void Armoire (bool toOpen) { StartCoroutine(ArmoireCoroutine(toOpen)); }
    IEnumerator ArmoireCoroutine (bool toOpen)
    {
        isAnimating = true;

        float time = 0f;
        float duration = 1f;
        Vector3 currentPosition = ArmoireDoorPosition.localPosition;
        Vector3 startPosition = currentPosition;
        Vector3 desiredPosition = new Vector3(toOpen ? xPosArmoireOpen : xPosArmoireClose, currentPosition.y, currentPosition.z);
        while (time < duration) {
            currentPosition = Vector3.Lerp(startPosition, desiredPosition, time / duration);
            ArmoireDoorPosition.localPosition = currentPosition;
            time += Time.deltaTime;
            yield return null;
        }
        ArmoireDoorPosition.localPosition = desiredPosition;
        isAnimating = false;
    }
    public void StopBlackestVoidMusic ()
    {
        if (BlackestVoidAudioSource.isPlaying) {
            BlackestVoidAudioSource.Stop();
        }
    }

    public void DressingDrawerAnimations (int int_id) { DressingAnimator.SetInteger("Dressing", int_id); }

    public void DoorShake () { DoorBedAnimator.Play("DoorShake"); }
    public void OpenCloseDoor () { DoorBedAnimator.SetBool("Open", !DoorBedAnimator.GetBool("Open")); }
    public void DoorSlideDown () {
        StartCoroutine(DoorSlideDownCoroutine());
    }
    IEnumerator DoorSlideDownCoroutine ()
    {
        isAnimating = true;
        DoorBedAnimator.enabled = false;

        float time = 0f;
        float duration = 1f;
        Vector3 currentPosition = DoorBedPosition.localPosition;
        Vector3 startPosition = currentPosition;
        Vector3 desiredPosition = new Vector3(currentPosition.x, yPosDoorBed, currentPosition.z);
        while (time < duration) {
            currentPosition = Vector3.Lerp(startPosition, desiredPosition, time / duration);
            DoorBedPosition.localPosition = currentPosition;
            time += Time.deltaTime;
            yield return null;
        }
        DoorBedPosition.localPosition = desiredPosition;
        DoorBedPosition.gameObject.SetActive(false);
        DoorBedAnimator.enabled = true;
        isAnimating = false;
    }
    
    public void Wait3Seconds () { StartCoroutine(WaitSecondsCoroutine(3)); }
    public void Wait5Seconds () { StartCoroutine(WaitSecondsCoroutine(5)); }
    public void Wait10Seconds () { StartCoroutine(WaitSecondsCoroutine(10)); }
    IEnumerator WaitSecondsCoroutine(float seconds) {
        isAnimating = true;
        yield return new WaitForSeconds(seconds);
        isAnimating = false;
    }

    #endregion
}
