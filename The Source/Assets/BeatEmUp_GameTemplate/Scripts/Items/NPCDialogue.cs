using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialogue : MonoBehaviour
{
    public float raycastDistance = 5f;
    public LayerMask playerLayer;
    public string[] dialogues;
    private int dialogueIndex = 0;

    public Text dialogueText; // Assign a UI Text element to display the dialogue
    private bool isPlayerNear = false;

    void Update()
    {
        CheckPlayerInRange();
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E)) // Assuming 'E' is the interact key
        {
            DisplayNextDialogue();
        }
    }

    void CheckPlayerInRange()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, raycastDistance, playerLayer);
        isPlayerNear = hit.collider != null;
    }

    void DisplayNextDialogue()
    {
        if (dialogueIndex < dialogues.Length)
        {
            dialogueText.text = dialogues[dialogueIndex];
            dialogueIndex++;
        }
        else
        {
            dialogueIndex = 0; // Reset the dialogue index to loop the dialogues
        }
    }
}
