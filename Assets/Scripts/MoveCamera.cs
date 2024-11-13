// Source https://www.youtube.com/watch?v=f473C43s8nE&t=1s&ab_channel=Dave%2FGameDevelopment
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform cameraPosition;
    // Update is called once per frame
    void Update()
    {
        transform.position = cameraPosition.position;   
    }
}
