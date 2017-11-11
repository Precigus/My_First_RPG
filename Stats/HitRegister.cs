using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class HitRegister : MonoBehaviour
{

    PlayerManager playerManager;
    CharacterStats myStats;
    public string targetTag;


    // Use this for initialization
    void Start()
    {
        playerManager = PlayerManager.instance;
        myStats = GetComponent<CharacterStats>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void OnCollisionEnter(Collision collision)
    {

        Collider thiscollider = collision.contacts[0].thisCollider;
        Collider othercollider = collision.contacts[0].otherCollider;

        //Debug.Log(thiscollider.gameObject.name);
        //Debug.Log(othercollider.gameObject.name); 
        CharacterStats damageSource = null;
        CharacterCombat damageDestination = null;

        if(thiscollider.gameObject.name == "SwordPoint")
        {
            damageDestination = othercollider.gameObject.GetComponent<CharacterCombat>();
            damageSource = thiscollider.gameObject.GetComponent<Weapon>().player.GetComponent<CharacterStats>();
        }
        else if (othercollider.gameObject.name == "SwordPoint") {
            damageDestination = thiscollider.gameObject.GetComponent<CharacterCombat>();
            damageSource = othercollider.gameObject.GetComponent<Weapon>().player.GetComponent<CharacterStats>();
        }

        else if (thiscollider.gameObject.name == "DamagePoint")
        {
            damageDestination = othercollider.gameObject.GetComponent<CharacterCombat>();
            damageSource = thiscollider.gameObject.GetComponent<Weapon>().player.GetComponent<CharacterStats>();
        }
        else if (othercollider.gameObject.name == "DamagePoint")
        {
            damageDestination = thiscollider.gameObject.GetComponent<CharacterCombat>();
            damageSource = othercollider.gameObject.GetComponent<Weapon>().player.GetComponent<CharacterStats>();
        }
        if (damageDestination == null)

            if (damageDestination == null)
            return;
        damageDestination.Attack(damageSource);
        return;
        //Debug.Log("HR myStats: "+ transform.name + " Damage: " + myStats.damage.getValue() + " Armor: " + myStats.armor.getValue() + " Hp: " + myStats.maxHealth + " CurrHP: " + myStats.currentHealth);

        //CharacterCombat playerCombat = playerManager.player.GetComponent<CharacterCombat>();
        //    collider.
        //    if (playerCombat != null)
        //    {
                
        //        playerCombat.Attack(myStats);
        //    }
        
    }
}