using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitboxBehaviour : MonoBehaviour
{
    public GameObject enemy;
    public bool hasHit;
    public float damage;

    void Start() {
        damage = enemy.GetComponent<TomatoController>().damage;
    }
    
    void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        Health health = other.GetComponent<Health>();
        if (player && !hasHit) {
            health.currentHealth = health.currentHealth - damage;
            hasHit = true;
            player.onHit();
        }
    }
}
