using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    #region SINGLETON DECLARATION

    private static Player instance;

    public static Player GetInstance () { return instance; }

    #endregion

    // PUBLIC
    [Header("Raycast")]
    public Transform RaycastPoint;
    [Range(0, 100)]
    public float maxDistance;
    public LayerMask Layer;

    [Header("Interface")]
    public GameObject UIObjectName;
    public TMP_Text UIObjectNameText;
    public GameObject UIInteractPrompt;
    public TMP_Text UIInteractionText;
    public Image BlackScreen;

    [Header("Dialogues")]
    public TextAsset Start_inkJSON;

    // PRIVATE
    private InteractableObject io;

    // Game variables
    public Dictionary<string, int> PlayerVariables = new Dictionary<string, int>();

    private void Awake ()
    {
        if (instance != null) {
            Debug.LogWarning("More than one instance of GameManager running");
        }

        instance = this;

        io = null;
        //BlackScreen.gameObject.SetActive(true); // TODO: ACTIVATE BEFORE FINAL RELEASE
        Color color = BlackScreen.color;
        color.a = 0;    // TODO: CHANGE BEFORE FINAL RELEASE
        BlackScreen.color = color;
    }

    void Start()
    {
        // "Quest items
        PlayerVariables.Add("mug", 1);
        //PlayerVariables.Add("mug", 0);
        PlayerVariables.Add("sugar", 1);
        //PlayerVariables.Add("sugar", 0);
        PlayerVariables.Add("milk", 1);
        //PlayerVariables.Add("milk", 0);
        PlayerVariables.Add("beka", 1);
        //PlayerVariables.Add("beka", 0);

        // Dialogue variables
        PlayerVariables.Add("blackestVoid", 0);
        PlayerVariables.Add("doorBedKey", 0);
        PlayerVariables.Add("cocoaPowder", 0);
        PlayerVariables.Add("greg", 0);

        //DialogueManager.GetInstance().StartDialogue(Start_inkJSON); // TODO: ACTIVATE BEFORE FINAL RELEASE
    }

    void Update ()
    {
        HandleUIPrompts();

        // Debug
        if (Input.GetKeyDown(KeyCode.I)) {
            DebugPlayerVariables();
        }
    }

    void FixedUpdate ()
    {
        CastInteractionRay();
    }

    private void CastInteractionRay ()
    {
        RaycastHit hitInfo;
        bool isHit = Physics.Raycast(RaycastPoint.position, RaycastPoint.forward, out hitInfo, maxDistance, Layer);

        if (isHit) {
            io = hitInfo.collider.GetComponent<InteractableObject>();
        } else {
            io = null;
        }

        // Debug
        if (isHit)
            Debug.DrawRay(RaycastPoint.position, RaycastPoint.forward * maxDistance, Color.green, 0f);
        else
            Debug.DrawRay(RaycastPoint.position, RaycastPoint.forward * maxDistance, Color.red, 0f);
    }

    private void HandleUIPrompts ()
    {
        if (io) {
            bool scc = AnimationManager.GetInstance().skyCrazyCond;
            UIObjectName.SetActive(true);
            UIObjectNameText.text = scc ? io.displayName.ToUpper() : io.displayName;
            UIInteractPrompt.SetActive(true);
            UIInteractionText.text = scc ? io.interactMessage.ToUpper() : io.interactMessage;

            if (!DialogueManager.GetInstance().isDialogueOpen && Input.GetKeyDown(KeyCode.F)) {
                io.OnInteract();
            }
        } else {
            UIObjectName.SetActive(false);
            UIInteractPrompt.SetActive(false);
        }
    }

    // DEBUG
    private void DebugPlayerVariables ()
    {
        foreach(KeyValuePair<string, int> variable in PlayerVariables) {
            Debug.Log("{0}: {1}");
        }
    }
}
