using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class EnemyController : MonoBehaviour
{
    public GameObject particle;
    public GameObject drop;
    public GameObject attackHitbox;
        
    public ParticleSystem particles;

    public Image healthBar;

    AudioSource audioData;
    
    public float damage = 10;

    void Start()
    {
        audioData = GetComponent<AudioSource>();
        attackHitbox.SetActive(false);
        StartMod();
    }
    public abstract void StartMod();

    void Update()
    {
        Health health = gameObject.GetComponent<Health>();
        healthBar.fillAmount = health.currentHealth / health.maxHealth;
        UpdateMod();
    }
    public abstract void UpdateMod();

    public void Hit() {
        Health health = gameObject.GetComponent<Health>();

        SpawnParticles();

        health.currentHealth -= 10;
        audioData.Play(0);

        if (health.currentHealth <= 0) {
            Destroy(gameObject);
        }
        HitMod();
    }
    public abstract void HitMod();

    public abstract void SpawnParticles();

    public void Attack() {
        attackHitbox.SetActive(true);
        AttackMod();
    }
    public abstract void AttackMod();

    public void StopAttack() {
        attackHitbox.SetActive(false);
        attackHitbox.GetComponent<EnemyHitboxBehaviour>().hasHit = false;
        StopAttackMod();
    }
    public abstract void StopAttackMod();
}
