using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
    private static DialogueManager instance;

    [Header("Dialogue UI")]
    public GameObject DialoguePanel;
    public TMP_Text DialogueText;
    public GameObject[] ChoiceButtons;
    public TMP_Text[] ChoicesText;

    public bool isDialogueOpen { get; private set; }
    private Story CurrentStory;

    private void Awake ()
    {
        if (instance != null) {
            Debug.LogWarning("More than one instance of Dialogue Manager running");
        }

        instance = this;
    }

    private void Start ()
    {
        isDialogueOpen = false;
        DialoguePanel.SetActive(false);
    }

    private void Update ()
    {
        if (!isDialogueOpen) {
            return;
        }

        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) { // Continue dialogue if possible
            ContinueDialogue();
        }
    }

    public void StartDialogue (TextAsset inkJSON)
    {
        CurrentStory = new Story(inkJSON.text);
        isDialogueOpen = true;
        DialoguePanel.SetActive(true);
        
        ContinueDialogue();
    }

    public void ContinueDialogue ()
    {
        if (CurrentStory.canContinue) {
            DialogueText.text = CurrentStory.Continue();
            DisplayChoices();
        } else {
            StartCoroutine(EndDialogue());
        }
    }

    public void DisplayChoices ()
    {
        List<Choice> currentChoices = CurrentStory.currentChoices;

        if (currentChoices.Count > ChoiceButtons.Length) {
            Debug.LogError("The amount of loaded choices are superior to the maximum allowed choices by the game UI");
        }

        int index = 0;
        foreach (Choice choice in currentChoices) {
            ChoiceButtons[index].gameObject.SetActive(true);
            ChoicesText[index].text = choice.text;
            index++;
        }

        for (int i = index; i < ChoiceButtons.Length; i++) {
            ChoiceButtons[i].SetActive(false);
        }

        StartCoroutine(SelectFirstChoice());
    }

    public IEnumerator SelectFirstChoice ()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(ChoiceButtons[0].gameObject);
    }

    public void SelectChoice (int choiceIndex)
    {
        CurrentStory.ChooseChoiceIndex(choiceIndex);
    }

    public IEnumerator EndDialogue ()
    {
        yield return new WaitForEndOfFrame();
        DialoguePanel.SetActive(false);
        DialogueText.text = "";
        isDialogueOpen = false;
    }

    public static DialogueManager GetInstance ()
    {
        return instance;
    }
}
