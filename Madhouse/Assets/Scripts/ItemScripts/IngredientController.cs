using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientController : MonoBehaviour
{
    public ItemObject item;
    public Transform target;
    Vector3 lookAtTarget;
    Vector3 direction;
    public bool canPickUp;
    public float pickupRange = 3f;
    public float travelSpeed;
    float targetDistance;
    public float rotationSpeed;
    void Start()
    {
        target = GameObject.Find("Player").GetComponent<Transform>();
    }

    void OnCollisionEnter(Collision collider)
    {
        if(collider.gameObject.CompareTag("Environment"))
        {
            canPickUp = true;
        }    
    }

    void LateUpdate()
    {
        targetDistance = Vector3.Distance(transform.position, target.position);
        direction = target.transform.position - this.transform.position;

        if(targetDistance < pickupRange && canPickUp) {
            FaceTarget();
            this.transform.Translate(0, 0, travelSpeed * Time.deltaTime);
        }
    }

    void FaceTarget() {
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
        Quaternion.LookRotation(direction),
        Time.deltaTime * rotationSpeed);
    }
}
