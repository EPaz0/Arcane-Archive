using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCSystem : MonoBehaviour
{
    public GameObject d_template;
    public GameObject canva;

    bool player_detection = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player_detection && Input.GetKeyDown(KeyCode.F) && !PlayerMovement.dialogue) 
        {
            PlayerMovement.dialogue = true;
            NewDialgoue("Hello there! How are you doing?");
            NewDialgoue("Test");
        }
        
    }
    void NewDialgoue(string text)
    {
        GameObject template_clone = Instantiate(d_template, d_template.transform);
        template_clone.transform.parent = canva.transform;
        template_clone.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = text;

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered Trigger: " + other.gameObject.name + " with tag: " + other.gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            player_detection = true;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
     
          player_detection = false;
        Debug.Log("Player exited");

    }
}
