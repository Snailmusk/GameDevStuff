using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggers : MonoBehaviour
{
    public ItemObject itemDrop;
    void OnTriggerEnter(Collider other)
    {
        var ingredient = other.GetComponent<IngredientController>();
        var player = GameObject.Find("Player").GetComponent<PlayerController>();

        if (ingredient) {  
            if(ingredient.canPickUp == true)
            {
                itemDrop = ingredient.item;
                player.addItemToInventory();
                Destroy(other.gameObject);
            }
        }
    }
}
