using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
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

    private void Awake ()
    {
        io = null;
        BlackScreen.gameObject.SetActive(true);
    }

    void Start()
    {
        //StartCoroutine(FadeFromBlackScreen());
        DialogueManager.GetInstance().StartDialogue(Start_inkJSON);
    }

    void Update ()
    {
        HandleUIPrompts();
    }

    void FixedUpdate ()
    {
        CastInteractionRay();
    }

    //private IEnumerator FadeFromBlackScreen ()
    //{
    //    DialogueManager.GetInstance().StartDialogue(Start_inkJSON);
    //    float time = 0;
    //    float duration = 5;
    //    Color currentColor = BlackScreen.color;
    //    while (time < duration) {
    //        currentColor.a = Mathf.Lerp(1, 0, time / duration);
    //        BlackScreen.color = currentColor;
    //        time += Time.deltaTime;
    //        yield return null;
    //    }
    //    currentColor.a = 0;
    //    BlackScreen.color = currentColor;
    //}

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
            UIObjectName.SetActive(true);
            UIObjectNameText.text = io.displayName;
            UIInteractPrompt.SetActive(true);
            UIInteractionText.text = io.interactMessage;

            if (Input.GetKeyDown(KeyCode.F)) {
                io.OnInteract();
            }
        } else {
            UIObjectName.SetActive(false);
            UIInteractPrompt.SetActive(false);
        }
    }
}
