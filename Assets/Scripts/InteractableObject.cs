using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [Header("Display")]
    public string id;
    public string displayName;
    public string interactMessage;
    
    [Header("Interactions")]
    public Animator Animator;
    public TextAsset inkJSON;

    public void OnInteract ()
    {
        Invoke(id + "Interaction", 0.0f);
    }

    #region // INTERACTION METHODS

    private void GuitarInteraction ()
    {
        DialogueInteraction();
    }

    private void DoorBedInteraction ()
    {
        OpenCloseDoor();
    }

    private void ClothesInteraction ()
    {
        Debug.Log("All my Uniqlo t-shirts are safe.");
    }

    #endregion // INTERACTION METHODS

    #region // GENERAL METHODS

    private void OpenCloseDoor ()
    {
        Animator.SetBool("Open", !Animator.GetBool("Open"));
    }

    private void DialogueInteraction ()
    {
        if (!DialogueManager.GetInstance().isDialogueOpen)
            DialogueManager.GetInstance().StartDialogue(inkJSON);
    }

    #endregion // GENERAL METHODS
}
