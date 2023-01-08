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
        if (!AS.isPlaying)
            AS.PlayOneShot(clip);
    }
    private void DoorBed () { DialogueInteractionWithVariable("doorBedKey", Player.GetInstance().PlayerVariables["doorBedKey"], this.gameObject); }
    private void Computer () { DialogueInteraction(this.gameObject); }
    private void CoffeeMug () { DialogueInteractionWithVariable("mug", Player.GetInstance().PlayerVariables["mug"], this.gameObject); }
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
            PlayOneShotClip();
            DialogueInteraction(this.gameObject);
        } else {
            DialogueInteractionWithVariable("blackestVoid", 1, this.gameObject);
        }
    }
    private void BedroomBottles () { DialogueInteraction(this.gameObject); }
    private void Drawer () { AnimationManager.GetInstance().DressingDrawerAnimations(int_id); }
    private void Wargame () { DialogueInteraction(this.gameObject); }
    private void Toilet () { DialogueInteraction(this.gameObject); }
    private void BathroomSinkWater () { DialogueInteractionWithVariable("greg", Player.GetInstance().PlayerVariables["greg"], this.gameObject); }
    private void Sugar () { DialogueInteraction(this.gameObject); }
    private void MatrixFlower () { DialogueInteraction(this.gameObject); }
    private void Shower () { DialogueInteraction(this.gameObject); }
    private void HotTub () { DialogueInteraction(this.gameObject); }
    private void InvisibleChair () { DialogueInteraction(this.gameObject); }
    private void RecordPlayer ()
    {
        if (AS.isPlaying)
            AS.Stop();
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
            Player.GetInstance().PlayerVariables["sugar"];

        DialogueInteractionWithVariable("questItems", questItemCount, this.gameObject);
    }
    private void DoorBath () { DialogueInteraction(this.gameObject); }
    private void FinalDoor () {
        int questItemCount =
            Player.GetInstance().PlayerVariables["milk"] +
            Player.GetInstance().PlayerVariables["mug"] +
            Player.GetInstance().PlayerVariables["sugar"] +
            Player.GetInstance().PlayerVariables["beka"];

        DialogueInteractionWithVariable("questItems", questItemCount, this.gameObject);
    }

    #endregion // INTERACTION METHODS

    #region // GENERAL METHODS  

    private void DialogueInteraction (GameObject interactableGameObject)
    {
        if (!DialogueManager.GetInstance().isDialogueOpen)
            DialogueManager.GetInstance().StartDialogue(inkJSON, interactableGameObject);
    }

    private void DialogueInteractionWithVariable (string variableName, int variableValue, GameObject interactableGameObject)
    {
        if (!DialogueManager.GetInstance().isDialogueOpen)
            DialogueManager.GetInstance().StartDialogueWithVariable(inkJSON, variableName, variableValue, interactableGameObject);
    }

    private void PlayOneShotClip ()
    {
        if (!AS.isPlaying) {
            AS.PlayOneShot(clip);
        }
    }

    #endregion // GENERAL METHODS
}
