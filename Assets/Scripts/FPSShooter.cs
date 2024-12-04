using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSShooter : MonoBehaviour
{
    public Camera cam;
    public GameObject projecticlePrefab;
    public Transform firepoint;
    public float projectileSpeed = 30f;
    public float fireRate = 4;
    private float timeToFire;

    private Vector3 destination;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= timeToFire) 
        {
            timeToFire = Time.time + 1 / fireRate;
            ShootProjecticle();
        }
        
    }

    void ShootProjecticle()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            destination = hit.point;
        }
        else
        {
            destination = ray.GetPoint(1000);
        }

        InstantiateProjecticle(firepoint);
    }


    void InstantiateProjecticle(Transform firepoint) 
    { 
        var projectileObj = Instantiate(projecticlePrefab, firepoint.position, Quaternion.identity) as GameObject;
        projectileObj.GetComponent<Rigidbody>().velocity = (destination - firepoint.position).normalized * projectileSpeed;
    }
}
