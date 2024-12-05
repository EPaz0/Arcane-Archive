using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    // You can set the name of the next scene here
    public string nextSceneName;  

    // This function is called when another collider enters the trigger zone
    private void OnTriggerEnter(Collider other)
    {
        // Check if the player (or any specific object) touches the object
        if (other.CompareTag("Player"))
        {
            // Load the next scene
            SceneManager.LoadScene(nextSceneName);
        }
    }
}

