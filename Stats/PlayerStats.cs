using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats {

    

	// Use this for initialization
	void Start () {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
	}
	
    void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        if (newItem != null)
        {
            armor.AddModifier(newItem.armorMod);
            damage.AddModifier(newItem.damageMod);
        }

        if (oldItem != null)
        {
            armor.RemoveModifier(oldItem.armorMod);
            damage.RemoveModifier(oldItem.damageMod);
        }

    }

    public override void Die()
    {
        base.Die();
        // Kill player;
        PlayerManager.instance.KillPlayer();
    }
}
