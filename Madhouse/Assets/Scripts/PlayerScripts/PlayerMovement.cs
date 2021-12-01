using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 6f;

    float horizontalMovement;
    float verticalMovement;
    public float rbDrag = 20f;

    Rigidbody rb;

    Vector3 moveDirection;

    private void Start() {
        rb = GetComponent<Rigidbody>();

        rb.freezeRotation = true;
    }

    private void Update() {
        MyInput();
        ControlDrag();
    }

    private void FixedUpdate() {
        MovePlayer();
    }

    void ControlDrag() {
        rb.drag = rbDrag;
    }

    void MyInput() {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");

        moveDirection = transform.forward * verticalMovement + transform.right * horizontalMovement;

    }

    void MovePlayer() {
        rb.AddForce(moveDirection.normalized * moveSpeed, ForceMode.Acceleration);
    }
}
