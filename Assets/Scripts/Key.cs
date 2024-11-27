using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
   
    public GameObject cubeToDisable;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Opening door")) // Check if the object is the door
        {
            Debug.Log("Key entered the trigger zone!");
            cubeToDisable.SetActive(false); // Disable the cube
        }
    }
}
