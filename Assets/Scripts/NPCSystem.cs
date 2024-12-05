using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCSystem : MonoBehaviour
{
    public DialogueManager dialogueManager; // Drag your DialogueManager here
    private bool playerDetection = false;

    void Update()
    {
        if (playerDetection && Input.GetKeyDown(KeyCode.F))
        {
            string[] dialogueLines = {
                "Hello there, adventurer!",
                "Your journey begins here. Be cautious and brave!",
                "Good luck!"
            };

            dialogueManager.StartDialogue(dialogueLines);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerDetection = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerDetection = false;
        }
    }
}

