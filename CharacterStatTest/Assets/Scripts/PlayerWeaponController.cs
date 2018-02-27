using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    public GameObject playerHand;
    public GameObject EquipedWeapon { get; set; }

    CharacterStats characterStat;

    IWeapon equipedWeapon;

    private void Start()
    {
        characterStat = GetComponent<CharacterStats>();
    }


    public void EquipItem(Item itemToEquip)
    {
        if (EquipedWeapon != null)
        {
            characterStat.RemoveStatBonus(EquipedWeapon.GetComponent<IWeapon>().Stats);
            Destroy(playerHand.transform.GetChild(0).gameObject);
        }
        EquipedWeapon = Instantiate(Resources.Load<GameObject>("Weapons/" + itemToEquip.ObjectSlug),playerHand.transform.position,playerHand.transform.rotation);
        equipedWeapon = EquipedWeapon.GetComponent<IWeapon>();
        EquipedWeapon.GetComponent<IWeapon>().Stats = itemToEquip.Stats;
        EquipedWeapon.transform.SetParent(playerHand.transform);
        characterStat.AddStatBonus(itemToEquip.Stats);
    }

    public void PerformAttack()
    {
        equipedWeapon.PerformAttack();
    }
}
