using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStillPos : MonoBehaviour
{
    [SerializeField] Transform enemyPos;

    // Update is called once per frame
    void Update()
    {
        transform.position = enemyPos.position;
    }
}
