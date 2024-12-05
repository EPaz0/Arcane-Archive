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
                "Welcome to endless library, to escape you must find the key and place it infront of the door",
                "Your magic will light the way (Use mouse 1 to shoot fireballs)"
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

