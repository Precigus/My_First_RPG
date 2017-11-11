using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{

    public float attackSpeed = 1f;
    private float attackCooldown = 0f;
    public float attackDelay = 1f;
    //private int _zala;
    //public int zala { get { return _zala; } set {
    //        _zala = value;
    //    } }
    //bool ppt = true;

    //[Header("Unity stuff")]
    //public Image healthBar;
    //public Text healthText;

    public event System.Action OnAttack;

    CharacterStats myStats;


    private void Start()
    {
        myStats = GetComponent<CharacterStats>();
        //if (ppt)
        //{
        //    zala = myStats.damage.getValue();
        //    ppt = false;
        //}
        //Debug.Log("CC myStats: " + transform.name + " Damage: " + myStats.damage.getValue() + " Armor: " + myStats.armor.getValue() + " Hp: " + myStats.maxHealth + " CurrHP: " + myStats.currentHealth);
        //Debug.Log(transform.name + " zala (Start): " + zala);
    }

    private void Update()
    {
        attackCooldown -= Time.deltaTime;
        //Debug.Log("CC myStats (update): " + transform.name + " Damage: " + myStats.damage.getValue() + " Armor: " + myStats.armor.getValue() + " Hp: " + myStats.maxHealth + " CurrHP: " + myStats.currentHealth);
    }


    public void Attack(CharacterStats targetStats)
    {
        if (attackCooldown <= 0)
        {
            //Debug.Log("CC myStats (Attack): " + transform.name + " Damage: " + myStats.damage.getValue() + " Armor: " + myStats.armor.getValue() + " Hp: " + myStats.maxHealth + " CurrHP: " + myStats.currentHealth);
            //Debug.Log("CC targetStats: " + transform.name + " Damage: " + targetStats.damage.getValue() + " Armor: " + targetStats.armor.getValue() + " Hp: " + targetStats.maxHealth + " CurrHP: " + targetStats.currentHealth);
            StartCoroutine(DoDamage(targetStats, attackDelay));

            if (OnAttack != null)
            {
                OnAttack();

            }
            attackCooldown = 1f / attackSpeed;

        }
    }

    IEnumerator DoDamage(CharacterStats stats, float delay)
    {
        yield return new WaitForSeconds(delay);
        //Debug.Log("CC myStats (DoDamage): " + transform.name + " Damage: " + myStats.damage.getValue() + " Armor: " + myStats.armor.getValue() + " Hp: " + myStats.maxHealth + " CurrHP: " + myStats.currentHealth);
        //Debug.Log("CC stats (DoDamage): " + transform.name + " Damage: " + stats.damage.getValue() + " Armor: " + stats.armor.getValue() + " Hp: " + stats.maxHealth + " CurrHP: " + stats.currentHealth);
        //Debug.Log("Zala: " + zala);
        myStats.TakeDamage(stats.damage.getValue());
        //Debug.Log(transform.name + " Does damage: " + myStats.damage.getValue());
        


    }
}
