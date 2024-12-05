using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch2 : MonoBehaviour
{
    public ParticleSystem flameParticle; // Assign in the Inspector
    public GameObject doorToDisable;     // Assign the door GameObject in the Inspector

    private bool isLit = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision Detected");
        if (other.CompareTag("bullet") && !isLit)
        {
            Debug.Log("Lighting Torch");
            isLit = true;
            flameParticle.Play(); // Enable particle system
            Destroy(other.gameObject); // Destroy the fireball
            if (doorToDisable != null)
            {
                doorToDisable.SetActive(false); // Disable the door
                Debug.Log("Door disabled");
            }
            else
            {
                Debug.LogWarning("No door assigned to disable.");
            }
        }
    }
}
