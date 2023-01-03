using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public string id;
    public string displayName;
    public bool hasInteraction;
    public string interactMessage;
    public Animator Animator;

    public void OnInteract ()
    {
        Invoke(id + "Interaction", 0.0f);
    }

    // INTERACTION METHODS
    private void GuitarInteraction ()
    {
        Debug.Log("I'm a guitar!");
    }

    private void DoorBedInteraction ()
    {
        OpenCloseDoor();
    }

    // GENERAL METHODS
    private void OpenCloseDoor ()
    {
        Animator.SetBool("Open", !Animator.GetBool("Open"));
    }
}
