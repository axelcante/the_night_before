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
    public Animator Animator;
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
    private void DoorBed () { OpenCloseDoor(); }
    private void Computer () { DialogueInteraction(this.gameObject); }
    private void CoffeeMug () { DialogueInteraction(this.gameObject); }
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
    private void Drawer () { Animator.SetInteger("Dressing", int_id); }
    private void Wargame () { DialogueInteraction(this.gameObject); }

    #endregion // INTERACTION METHODS

    #region // GENERAL METHODS

    private void OpenCloseDoor () { Animator.SetBool("Open", !Animator.GetBool("Open")); }

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
