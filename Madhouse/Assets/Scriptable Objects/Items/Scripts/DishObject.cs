using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Dish Object", menuName = "Inventory System/Items/Dish")]
public class DishObject : ItemObject
{
   public void Awake() {
       type = ItemType.Dish;
   }
}
