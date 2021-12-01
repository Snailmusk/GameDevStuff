using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LettuceMovementBehaviour : MonoBehaviour
{
    public float speed = 2.0f;
    public float startHealRange = 0.01f;
    public float rotSpeed = 0.1f;

    float targetDistance;
    bool targetDamaged;

    public Transform target;

    Animator animator;

    Vector3 lookAtTarget;
    Vector3 direction;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void LateUpdate()
    {
        targetDistance = Vector3.Distance(transform.position, target.position);
        lookAtTarget = new Vector3(target.position.x, this.transform.position.y, target.position.z);
        direction = lookAtTarget - this.transform.position;

        animator.SetBool("Idling", true);
        animator.SetBool("Healing", false);
        animator.SetBool("Death", false);

        if (targetDamaged && targetDistance > startHealRange) {
            FaceTarget();
            MoveToTarget();
        } else if (targetDamaged && targetDistance < startHealRange) {
            FaceTarget(); 
            HealTarget();
        }
    }

    void OnTriggerStay(Collider other)
    {
        Health health = other.GetComponent<Health>();

        if (other.tag == "Enemy") {
            target = other.GetComponent<Transform>();
            if (health.currentHealth < health.maxHealth) {
                targetDamaged = true;
            }
        }
    }
    
    void FaceTarget() {
        //rotates character in direction of target
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, 
        Quaternion.LookRotation(direction), 
        Time.deltaTime * rotSpeed);
    }

    void MoveToTarget() {
        this.transform.Translate(0, 0, speed * Time.deltaTime);
    }

    void HealTarget() {
        animator.SetBool("Idling", false);
        animator.SetBool("Healing", true);
    }
}
