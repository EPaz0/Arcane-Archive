//Source: https://www.youtube.com/watch?v=f473C43s8nE&t=1s&ab_channel=Dave%2FGameDevelopment
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;

    float xRotation;
    float yRotation;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // If dialogue is active, disable camera movement and unlock the cursor
        if (PlayerMovement.dialogue)
        {
            Cursor.lockState = CursorLockMode.None; // Unlock the cursor for dialogue interaction
            Cursor.visible = true;                 // Make the cursor visible
            return;                                // Skip the rest of the Update logic
        }

        // Ensure the cursor is locked and hidden during normal gameplay
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Rotate cam and orientation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
