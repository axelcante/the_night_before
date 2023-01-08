using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [Header("Display")]
    public string id;
    public int int_id;
    public string displayName;
    public string interactMessage;

    [Header("Interactions")]
    public TextAsset inkJSON;
    public AudioSource AS;
    public AudioClip clip;

    private bool isArmoireOpen = false;

    // INVOKER METHOD
    public void OnInteract () { Invoke(id, 0.0f); }

    #region // INTERACTION METHODS (Invoked)

    private void Ceiling () { DialogueInteraction(this.gameObject); }
    private void Bed () { DialogueInteraction(this.gameObject); }
    private void Guitar () {
        if (!AS.isPlaying) {
            AS.PlayOneShot(clip);
        }
    }
    private void DoorBed () { DialogueInteractionWithVariable(new string[] { "doorBedKey" }, new int[] { Player.GetInstance().PlayerVariables["doorBedKey"] }, this.gameObject); }
    private void Computer () { DialogueInteraction(this.gameObject); }
    private void CoffeeMug () { DialogueInteractionWithVariable(new string[] { "mug" }, new int[] { Player.GetInstance().PlayerVariables["mug"] }, this.gameObject); }
    private void DeskButton () { DialogueInteraction(this.gameObject); }
    private void Books () { DialogueInteraction(this.gameObject); }
    private void DeskChair () { DialogueInteraction(this.gameObject); }
    private void Clothes () { DialogueInteraction(this.gameObject); }
    private void BedroomPlant () { DialogueInteraction(this.gameObject); }
    private void Armoire () {
        if (!isArmoireOpen) {
            AnimationManager.GetInstance().Armoire(true);
            isArmoireOpen = true;
        } else {
            AnimationManager.GetInstance().Armoire(false);
            isArmoireOpen = false;
        }
    }
    private void BlackestVoid () {
        if (Player.GetInstance().PlayerVariables["blackestVoid"] == 0) {
            AnimationManager.GetInstance().DiscAS.Stop();
            PlayOneShotClip();
            DialogueInteraction(this.gameObject);
        } else {
            DialogueInteractionWithVariable(new string[] { "blackestVoid" }, new int[] { 1 }, this.gameObject);
        }
    }
    private void BedroomBottles () { DialogueInteraction(this.gameObject); }
    private void Drawer () { AnimationManager.GetInstance().DressingDrawerAnimations(int_id); }
    private void Wargame () { DialogueInteraction(this.gameObject); }
    private void Toilet () { DialogueInteraction(this.gameObject); }
    private void BathroomSinkWater () { DialogueInteractionWithVariable(new string[] { "greg" }, new int[] { Player.GetInstance().PlayerVariables["greg"] }, this.gameObject); }
    private void Sugar () { DialogueInteraction(this.gameObject); }
    private void MatrixFlower () { DialogueInteraction(this.gameObject); }
    private void Shower () { DialogueInteraction(this.gameObject); }
    private void HotTub () { DialogueInteraction(this.gameObject); }
    private void InvisibleChair () { DialogueInteraction(this.gameObject); }
    private void RecordPlayer ()
    {
        if (AS.isPlaying)
            AS.Pause();
        else
            AS.Play();
        AnimationManager.GetInstance().StopStartDisc();
    }
    private void PS5 () { DialogueInteraction(this.gameObject); }
    private void LivingRoomBottles () { DialogueInteraction(this.gameObject); }
    private void Pestos () { DialogueInteraction(this.gameObject); }
    private void BigFreezerDoor () { AnimationManager.GetInstance().OpenCloseBigFreezerDoor(); }
    private void SmallFreezerDoor () { AnimationManager.GetInstance().OpenCloseSmallFreezerDoor(); }
    private void BigFridgeDoor () { AnimationManager.GetInstance().OpenCloseBigFridgeDoor(); }
    private void SmallFridgeDoor () { AnimationManager.GetInstance().OpenCloseSmallFridgeDoor(); }
    private void PastaTools () { DialogueInteraction(this.gameObject); }
    private void LivingRoomPlant () { DialogueInteraction(this.gameObject); }
    private void FruitBowl () { DialogueInteraction(this.gameObject); }
    private void Stove () { AnimationManager.GetInstance().Stove(); }
    private void Beka ()
    {
        int questItemCount =
            Player.GetInstance().PlayerVariables["milk"] +
            Player.GetInstance().PlayerVariables["mug"] +
            Player.GetInstance().PlayerVariables["sugar"] +
            Player.GetInstance().PlayerVariables["beka"];

        int cocoa = Player.GetInstance().PlayerVariables["cocoaPowder"];

        DialogueInteractionWithVariable(new string[] { "questItems", "cocoa" }, new int[] { questItemCount, cocoa }, this.gameObject);
    }
    private void DoorBath () { DialogueInteraction(this.gameObject); }
    private void FinalDoor () {
        int questItemCount =
            Player.GetInstance().PlayerVariables["milk"] +
            Player.GetInstance().PlayerVariables["mug"] +
            Player.GetInstance().PlayerVariables["sugar"] +
            Player.GetInstance().PlayerVariables["beka"];

        DialogueInteractionWithVariable(new string[] { "questItems" }, new int[] { questItemCount }, this.gameObject);
    }

    #endregion // INTERACTION METHODS

    #region // GENERAL METHODS  

    private void DialogueInteraction (GameObject interactableGameObject)
    {
        if (!DialogueManager.GetInstance().isDialogueOpen)
            DialogueManager.GetInstance().StartDialogue(inkJSON, interactableGameObject);
    }

    private void DialogueInteractionWithVariable (string[] variablesName, int[] variablesValue, GameObject interactableGameObject)
    {
        if (!DialogueManager.GetInstance().isDialogueOpen)
            DialogueManager.GetInstance().StartDialogueWithVariable(inkJSON, variablesName, variablesValue, interactableGameObject);
    }

    private void PlayOneShotClip ()
    {
        if (!AS.isPlaying) {
            AS.PlayOneShot(clip);
        }
    }

    #endregion // GENERAL METHODS
}
