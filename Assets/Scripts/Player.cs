using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    // PUBLIC
    [Header("Raycast")]
    public Transform RaycastPoint;
    [Range(0, 100)]
    public float maxDistance;
    public LayerMask Layer;

    [Header("Interface")]
    public DialogueManager DM;
    public GameObject UIObjectName;
    public TMP_Text UIObjectNameText;
    public GameObject UIInteractPrompt;
    public TMP_Text UIInteractionText;

    // PRIVATE
    private InteractableObject io;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update ()
    {
        if (io) {
            UIObjectName.SetActive(true);
            UIObjectNameText.text = io.displayName;

            if (io.hasInteraction) {
                UIInteractPrompt.SetActive(true);
                UIInteractionText.text = io.interactMessage;

                if (Input.GetKeyDown(KeyCode.F)) {
                    io.OnInteract();
                }
            }
        } else {
            UIObjectName.SetActive(false);
            UIInteractPrompt.SetActive(false);
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
}