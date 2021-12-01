using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeController : MonoBehaviour
{
    public GameObject hitbox;
    GameObject player;
    Animator animator;
    AudioSource audioData;
    public float damage;
    public float attackDelay;
    public float attackDuration;
    bool hitBoxIsActive;

    void Start()
    {
        player = GameObject.Find("Player");
        animator = GetComponent<Animator>();
        audioData = GetComponent<AudioSource>();

        hitbox.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            animator.SetBool("Attacking", true);
        }

        if (Input.GetMouseButtonUp(0)) {
            animator.SetBool("Attacking", false);
        }

        if (Input.GetAxisRaw("Horizontal") > 0 || Input.GetAxisRaw("Vertical") > 0) {
            animator.SetBool("Moving", true);
        } else {
            animator.SetBool("Moving", false);
        }
    }
    void Attack() {
        audioData.Play(0);
        hitbox.SetActive(true);
    }    

    void StopAttack() {
        hitbox.SetActive(false);
        hitbox.GetComponent<WeaponHitboxBehaviour>().enemyHit = false; //resets the "Has hit enemy" variable
    }
}
