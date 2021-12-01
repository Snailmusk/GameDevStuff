using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeAnimations : MonoBehaviour
{
    Animator animator;
    AudioSource audioData;
    public Animation anim;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioData = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            animator.SetTrigger("Attack");
            audioData.Play(0);
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
}
