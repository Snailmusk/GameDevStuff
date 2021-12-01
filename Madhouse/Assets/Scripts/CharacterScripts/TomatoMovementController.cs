using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomatoMovementController : MonoBehaviour
{
    public float speed = 2.0f;
    public float attackRange = 0.01f;
    public float aggroRange = 10;
    public float rotSpeed = 0.1f;

    float targetDistance;

    public Transform target;

    Animator animator;

    Vector3 lookAtTarget;
    Vector3 direction;

    void Start()
    {
        animator = GetComponent<Animator>();
        target = GameObject.Find("Player").GetComponent<Transform>();
    }

    void LateUpdate()
    {
        targetDistance = Vector3.Distance(transform.position, target.position);
        lookAtTarget = new Vector3(target.position.x, this.transform.position.y, target.position.z);
        direction = lookAtTarget - this.transform.position;

        FaceTarget();

        animator.SetBool("Idling", true);
        animator.SetBool("Attacking", false);
        animator.SetBool("Moving", false);

        if(targetDistance < aggroRange && targetDistance > attackRange) {
            MoveToTarget();
        }

        if(targetDistance < attackRange + .5) {
            AttackTarget();
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
        animator.SetBool("Attacking", false);
        animator.SetBool("Moving", true);
    }

    void AttackTarget() {
        animator.SetBool("Moving", false);
        animator.SetBool("Attacking", true);
    }

}