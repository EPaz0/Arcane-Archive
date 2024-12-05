using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallRespawn : MonoBehaviour
{
    // The position where the player will be teleported.
    public Transform teleportDestination;

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object colliding is the player (you can add a tag to the player for better detection)
        if (collision.gameObject.CompareTag("Player"))
        {
            // Teleport the player to the specified location
            collision.gameObject.transform.position = teleportDestination.position;
        }
    }
}
