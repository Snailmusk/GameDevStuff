using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Weapon", menuName = "Inventory System/Items/Weapon")]
public class WeaponObject : ItemObject
{
    public float damage;
    public float durability;
    public float sharpness;
    void Awake()
    {
        type = ItemType.Weapon;
    }
}
