using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IHittable
{
    
    public GameObject equippedWeapon;
    public AudioSource audioData;
    public AudioClip playerHitSound;
    public AudioClip itemCollectSound;
    public InventoryObject inventory;
    public bool isAttacking;
    void Update()
    {
        if(gameObject.GetComponent<Health>().currentHealth <= 0) {
            onDeath();
        }
    }

    public void onHit() {
        audioData.PlayOneShot(playerHitSound, 1);
    }

    public void addItemToInventory() {
        var playerTrigger = GetComponentInChildren<PlayerTriggers>();

        audioData.PlayOneShot(itemCollectSound, .5f);
        inventory.AddItem(playerTrigger.itemDrop, 1);
    }

    void onDeath() {
        
    }

    private void OnApplicationQuit() {
        inventory.Container.Clear(); //clears inventory after you close the game.
    }
}
