using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchManager : MonoBehaviour
{
    public static TorchManager Instance;
    public int totalTorches = 3; // Set the number of torches in the level
    private int litTorches = 0;
    public GameObject door; // Assign the door GameObject in the Inspector

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TorchLit()
    {
        litTorches++;
        if (litTorches >= totalTorches)
        {
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        // Example: Disable the door or play an animation
        door.SetActive(false); // This assumes the door GameObject disables when opened
        Debug.Log("Door Opened!");
    }
}
