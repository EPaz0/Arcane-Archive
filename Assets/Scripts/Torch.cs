using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    public ParticleSystem flameParticle; // Assign in the Inspector
    private bool isLit = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision Deted");
        if (other.CompareTag("bullet") && !isLit)
        {
            Debug.Log("Lighting Torch");
            isLit = true;
            flameParticle.Play(); // Enable particle system
            Destroy(other.gameObject); // Destroy the fireball
            TorchManager.Instance.TorchLit(); // Notify the manager
        }
    }
}