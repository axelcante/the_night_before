using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Image BlackScreenMenu;
    public GameObject PlayButton;
    public AudioSource AS;

    private void Start ()
    {
        //Cursor.lockState = CursorLockMode.None;
        StartCoroutine(FadeMenuBlackScreen(false));
    }

    public void StartGame ()
    {
        StartCoroutine(StartGameCoroutine());
    }

    IEnumerator StartGameCoroutine ()
    {
        PlayButton.SetActive(false);
        yield return FadeMenuBlackScreen(true);
        yield return FadeOutMusicCoroutine();
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(1);
    }

    IEnumerator FadeMenuBlackScreen (bool toBlack, float duration = 5)
    {
        float time = 0;
        Color currentColor = BlackScreenMenu.color;
        float targetAlpha = toBlack ? 1 : 0;
        float startAlpha = toBlack ? 0 : 1;
        while (time < duration) {
            currentColor.a = Mathf.Lerp(startAlpha, targetAlpha, time / duration);
            BlackScreenMenu.color = currentColor;
            time += Time.deltaTime;
            yield return null;
        }
        currentColor.a = targetAlpha;
        BlackScreenMenu.color = currentColor;

        if (!toBlack)
            PlayButton.SetActive(true);
    }

    private IEnumerator FadeOutMusicCoroutine (float fadeTime = 1f)
    {
        float startVolume = AS.volume;

        while (AS.volume > 0) {
            AS.volume -= startVolume * Time.deltaTime / fadeTime;
            yield return null;
        }

        AS.Stop();
        AS.volume = startVolume;
    }
}
