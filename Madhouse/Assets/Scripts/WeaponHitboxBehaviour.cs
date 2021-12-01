using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHitboxBehaviour : MonoBehaviour
{
    public bool enemyHit;
    
    void OnTriggerEnter(Collider other) {

        EnemyController c = other.GetComponent<EnemyController>();
            c.Hit();
            enemyHit = true; 
    }
}
