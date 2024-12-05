using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private bool collided;
    public GameObject impactVX;
    void OnCollisionEnter(Collision co) 
    {
        if (co.gameObject.tag != "Bullet" && co.gameObject.tag != "Player" && !collided) 
        {
            collided = true;

            var impact = Instantiate(impactVX, co.contacts[0].point, Quaternion.identity) as GameObject;

            Destroy(impact, 2f);
            Destroy(gameObject);
        }
        
    }
}
