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
    public bool skyCrazyCond = false;

    public static AnimationManager GetInstance () { return instance; }

    #endregion

    #region ANIMATION GAMEOBJECTS

    [Header("Day Display")]
    public TMP_Text DayDisplayText;
    [Header("Black Screen")]
    public Image BlackScreen;
    [Header("Coffee Mug")]
    public Transform LiquidPositionBed;
    public Transform LiquidPositionLiv;
    public float yPosLiquid;
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
    [Header("Toilet")]
    public Transform ToiletPosition;
    public float yPosToilet;
    [Header("BathroomSink")]
    public Transform SugarPosition;
    public float yPosSugar;
    public Transform BathSinkWaterPosition;
    public float yPoBathSinkWater;
    [Header("Disc")]
    public AudioSource DiscAS;
    public Animator DiscAnimator;
    public float discAnimDelay;
    [Header("Living Room Bottles")]
    public Transform Bottles1;
    public Transform Bottles2;
    public float yPosBottles;
    [Header("Fridge")]
    public Animator FridgeAnimator;
    [Header("Stove")]
    public AudioSource StoveAS;
    public Animator StoveAnimator;
    public float technoTime;
    [Header("Beka")]
    public GameObject ContactlessIcon;
    public GameObject BekaMug;
    public Transform BekaLiquid;
    public float yPosBekaLiquid;
    [Header("Sky Colors")]
    public Camera MC;
    public Light DL;
    public float drugIntensity;
    public Color[] SkyColors;

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

    public void CoffeeDrink () {
        StartCoroutine(CoffeeDrinkCoroutine(LiquidPositionBed));
        StartCoroutine(CoffeeDrinkCoroutine(LiquidPositionLiv));
    }
    IEnumerator CoffeeDrinkCoroutine (Transform LiquidPosition)
    {
        isAnimating = true;

        float time = 0f;
        float duration = 2f;
        Vector3 currentPosition = LiquidPosition.localPosition;
        Vector3 startPosition = currentPosition;
        Vector3 desiredPosition = new Vector3(currentPosition.x, yPosLiquid, currentPosition.z);
        while (time < duration) {
            currentPosition = Vector3.Lerp(startPosition, desiredPosition, time / duration);
            LiquidPosition.localPosition = currentPosition;
            time += Time.deltaTime;
            yield return null;
        }
        LiquidPosition.localPosition = desiredPosition;
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
    public void DoorSlideDown () { StartCoroutine(DoorSlideDownCoroutine()); }
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

    public void ToiletSlideDown () { StartCoroutine(ToiletSlideDownCoroutine()); }
    IEnumerator ToiletSlideDownCoroutine ()
    {
        isAnimating = true;

        float time = 0f;
        float duration = 1f;
        Vector3 currentPosition = ToiletPosition.localPosition;
        Vector3 startPosition = currentPosition;
        Vector3 desiredPosition = new Vector3(currentPosition.x, yPosToilet, currentPosition.z);
        while (time < duration) {
            currentPosition = Vector3.Lerp(startPosition, desiredPosition, time / duration);
            ToiletPosition.localPosition = currentPosition;
            time += Time.deltaTime;
            yield return null;
        }
        ToiletPosition.localPosition = desiredPosition;
        ToiletPosition.gameObject.SetActive(false);
        isAnimating = false;
    }

    public void SugarSlideUp () { StartCoroutine(SugarSlideUpCoroutine()); }
    public void BathroomSinkWaterSlideDown () { StartCoroutine(BathroomSinkWaterSlideDownCoroutine()); }
    IEnumerator SugarSlideUpCoroutine ()
    {
        isAnimating = true;
        SugarPosition.gameObject.SetActive(true);

        float time = 0f;
        float duration = 1f;
        Vector3 currentPosition = SugarPosition.localPosition;
        Vector3 startPosition = currentPosition;
        Vector3 desiredPosition = new Vector3(currentPosition.x, yPosSugar, currentPosition.z);
        while (time < duration) {
            currentPosition = Vector3.Lerp(startPosition, desiredPosition, time / duration);
            SugarPosition.localPosition = currentPosition;
            time += Time.deltaTime;
            yield return null;
        }
        SugarPosition.localPosition = desiredPosition;
        isAnimating = false;
    }
    IEnumerator BathroomSinkWaterSlideDownCoroutine ()
    {
        isAnimating = true;

        float time = 0f;
        float duration = 1f;
        Vector3 currentPosition = BathSinkWaterPosition.localPosition;
        Vector3 startPosition = currentPosition;
        Vector3 desiredPosition = new Vector3(currentPosition.x, yPoBathSinkWater, currentPosition.z);
        while (time < duration) {
            currentPosition = Vector3.Lerp(startPosition, desiredPosition, time / duration);
            BathSinkWaterPosition.localPosition = currentPosition;
            time += Time.deltaTime;
            yield return null;
        }
        BathSinkWaterPosition.localPosition = desiredPosition;
        BathSinkWaterPosition.gameObject.SetActive(false);
        isAnimating = false;
    }

    public void StopStartDisc () { StartCoroutine(DelayDiscStopStart()); }
    IEnumerator DelayDiscStopStart ()
    {
        yield return new WaitForSeconds(discAnimDelay);
        DiscAnimator.speed = DiscAnimator.speed == 1 ? 0 : 1;
    }
    
    public void LivingRoomBottlesSlideDown () { StartCoroutine(LivingRoomBottlesSlideDownCoroutine()); }
    IEnumerator LivingRoomBottlesSlideDownCoroutine ()
    {
        isAnimating = true;

        float time = 0f;
        float duration = 1f;
        Vector3 currentPosition1 = Bottles1.localPosition;
        Vector3 currentPosition2 = Bottles2.localPosition;
        Vector3 startPosition1 = currentPosition1;
        Vector3 startPosition2 = currentPosition2;
        Vector3 desiredPosition1 = new Vector3(currentPosition1.x, yPosBottles, currentPosition1.z);
        Vector3 desiredPosition2 = new Vector3(currentPosition2.x, yPosBottles, currentPosition2.z);
        while (time < duration) {
            currentPosition1 = Vector3.Lerp(startPosition1, desiredPosition1, time / duration);
            currentPosition2 = Vector3.Lerp(startPosition2, desiredPosition2, time / duration);
            Bottles1.localPosition = currentPosition1;
            Bottles2.localPosition = currentPosition2;
            time += Time.deltaTime;
            yield return null;
        }
        Bottles1.localPosition = desiredPosition1;
        Bottles2.localPosition = desiredPosition2;
        Bottles1.gameObject.SetActive(false);
        Bottles2.gameObject.SetActive(false);
        isAnimating = false;
    }

    public void OpenCloseBigFreezerDoor () { FridgeAnimator.SetBool("OpenBigFreezer", !FridgeAnimator.GetBool("OpenBigFreezer")); }
    public void OpenCloseBigFridgeDoor () { FridgeAnimator.SetBool("OpenBigFridge", !FridgeAnimator.GetBool("OpenBigFridge")); }
    public void OpenCloseSmallFreezerDoor () { FridgeAnimator.SetBool("OpenSmallFreezer", !FridgeAnimator.GetBool("OpenSmallFreezer")); }
    public void OpenCloseSmallFridgeDoor () { FridgeAnimator.SetBool("OpenSmallFridge", !FridgeAnimator.GetBool("OpenSmallFridge")); }

    public void Stove () {
        if (!StoveAS.isPlaying)
            StartCoroutine(StoveCoroutine());
    }
    IEnumerator StoveCoroutine ()
    {
        DiscAS.Stop();
        StoveAS.Play();
        StoveAnimator.Play("Stove");
        yield return new WaitForSeconds(technoTime);
        StoveAS.Stop();
        StoveAnimator.Play("Default");
        DiscAS.Play();
    }

    public void ToggleContactless () { ContactlessIcon.SetActive(!ContactlessIcon.activeSelf); }
    public void ToggleBekaMug () { BekaMug.SetActive(!BekaMug.activeSelf); }
    public void FillCoffee () { StartCoroutine(FillCoffeeCoroutine()); }
    IEnumerator FillCoffeeCoroutine ()
    {
        isAnimating = true;
        BekaLiquid.gameObject.SetActive(true);

        float time = 0f;
        float duration = 4f;
        Vector3 currentPosition = BekaLiquid.localPosition;
        Vector3 startPosition = currentPosition;
        Vector3 desiredPosition = new Vector3(currentPosition.x, yPosBekaLiquid, currentPosition.z);
        while (time < duration) {
            currentPosition = Vector3.Lerp(startPosition, desiredPosition, time / duration);
            BekaLiquid.localPosition = currentPosition;
            time += Time.deltaTime;
            yield return null;
        }
        BekaLiquid.localPosition = desiredPosition;

        isAnimating = false;
    }

    public void SkyDrugCrazyStart () {
        skyCrazyCond = true;
        DL.intensity = drugIntensity;
        StartCoroutine(SkyDrugCrazyCoroutine());
    }
    public void SkyDrugCrazyStop () { skyCrazyCond = false; }
    IEnumerator SkyDrugCrazyCoroutine ()
    {
        while (skyCrazyCond) {
            MC.backgroundColor = SkyColors[Random.Range(0, SkyColors.Length)];
            yield return new WaitForSeconds(2);
        }
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
