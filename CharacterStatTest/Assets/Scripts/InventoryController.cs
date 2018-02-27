using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    PlayerWeaponController weaponController;
    public Item sword;

    private void Start()
    {
        weaponController = gameObject.GetComponent<PlayerWeaponController>();
        List<BaseStat> swordStats = new List<BaseStat>();
        swordStats.Add(new BaseStat(6, "Power", "Your power level"));
        sword = new Item(swordStats, "sword");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            weaponController.EquipItem(sword);

        }
    }



}
