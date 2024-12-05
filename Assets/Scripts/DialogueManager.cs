using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialoguePanel; // Dialogue UI panel
    public TextMeshProUGUI dialogueText; // Dialogue text element

    private Queue<string> dialogueQueue = new Queue<string>();
    private bool isDialogueActive = false;

    public void StartDialogue(string[] lines)
    {
        dialogueQueue.Clear();
        foreach (string line in lines)
        {
            dialogueQueue.Enqueue(line);
        }

        PlayerMovement.dialogue = true; // Freeze the player
        isDialogueActive = true;
        dialoguePanel.SetActive(true);
        DisplayNextLine();
    }

    public void DisplayNextLine()
    {
        if (dialogueQueue.Count == 0)
        {
            EndDialogue();
            return;
        }

        string currentLine = dialogueQueue.Dequeue();
        dialogueText.text = currentLine;
    }

    private void EndDialogue()
    {
        isDialogueActive = false;
        dialoguePanel.SetActive(false);
        PlayerMovement.dialogue = false; // Unfreeze the player
    }

    void Update()
    {
        if (isDialogueActive && Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNextLine();
        }
    }
}