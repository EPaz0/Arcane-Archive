using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private LayerMask pickableLayermask;

    [SerializeField]
    private Transform playerCameraTransform;

    [SerializeField]
    private GameObject pickUpUI;

    [SerializeField]
    [Min(1)]
    private float hitRange = 3;

    [SerializeField]
    private Transform pickUpParent;

    [SerializeField]
    private GameObject inHandItem;



    private RaycastHit hit;


    private void Update()
    {


        Debug.DrawRay(playerCameraTransform.position, playerCameraTransform.forward*hitRange, Color.red);


        if(inHandItem == null)
        {
            if (hit.collider != null)
            {
                hit.collider.GetComponent<Highlight>()?.ToggleHighlight(false);
                pickUpUI.SetActive(false);
            }

            if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out hit, hitRange, pickableLayermask))
            {
                hit.collider.GetComponent<Highlight>()?.ToggleHighlight(true);
                pickUpUI.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (hit.collider != null)
                {
                    if (hit.collider.GetComponent<Key>())
                    {
                        //Debug.Log(hit.collider.name);
                        Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
                        Collider objCollider = hit.collider.GetComponent<Collider>();
                        
                  

                        inHandItem = hit.collider.gameObject;


                        inHandItem.transform.position = Vector3.zero;
                        inHandItem.transform.rotation = Quaternion.identity;
                        inHandItem.transform.SetParent(pickUpParent.transform, false);


                        inHandItem.GetComponent<Highlight>()?.ToggleHighlight(false);

                        if (rb != null)
                        {
                            rb.isKinematic = true;
                        }

                        if (objCollider != null)
                        {
                            objCollider.enabled = false; // Disable collider to avoid pushing
                        }


                   
                        return;
                    }
                }
            }

        }

        if (inHandItem != null)
        {
            pickUpUI.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Q)) 
        {
            Debug.Log("Q pressed");
            if (inHandItem != null) 
            { 
                inHandItem.transform.SetParent(null);
                
                Rigidbody rb = inHandItem.GetComponent<Rigidbody>();
                Collider objCollider = inHandItem.GetComponent<Collider>();
                if (rb != null)
                {
                    rb.isKinematic = false;
                }

                if (objCollider != null)
                {
                    objCollider.enabled = true; // Re-enable collider
                }
                inHandItem = null;
            }
        }



    }
}
