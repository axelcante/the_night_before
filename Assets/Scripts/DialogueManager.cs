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
    public TextMeshProUGUI DialogueText;
    public GameObject[] ChoiceButtons;
    public TextMeshProUGUI[] ChoicesText;

    [Header("Text Display")]
    public Color playerColor;
    public Color otherColor;

    public bool isDialogueOpen { get; private set; }
    public bool isMakingChoice { get; private set; }
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
        isMakingChoice = false;
        DialoguePanel.SetActive(false);
    }

    private void Update ()
    {
        if (!isDialogueOpen) {
            return;
        }

        if (!AnimationManager.GetInstance().isAnimating) {
            if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) { // Continue dialogue if possible
                ContinueDialogue();
            }
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
            if (CurrentStory.currentTags.Count > 0) {
                ParseStrings(CurrentStory.currentTags);
            } else {
                DialogueText.color = otherColor;
            }
            DisplayChoices();
        } else {
            StartCoroutine(EndDialogue());
        }
    }

    public void DisplayChoices ()
    {
        List<Choice> currentChoices = CurrentStory.currentChoices;

        if (currentChoices.Count == 0) {
            isMakingChoice = false;
            for (int i = 0; i < ChoiceButtons.Length; i++) {
                ChoiceButtons[i].SetActive(false);
            }
        } else {
            isMakingChoice = true;
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

    private string[] ParseStrings (List<string> tags)
    {
        foreach (string tag in tags) {
            string[] tagCommands = tag.Split(':');
            if (tagCommands.Length > 0) {
                for (int i = 0; i < tagCommands.Length; i++) {
                    if (tagCommands[i] == "animate") {
                        AnimationManager.GetInstance().Invoke(tagCommands[1], 0f);
                    } else if (tagCommands[i] == "player") {
                        DialogueText.color = playerColor;
                    }
                }
            }
        }
        return null;
    }

    public static DialogueManager GetInstance ()
    {
        return instance;
    }
}
