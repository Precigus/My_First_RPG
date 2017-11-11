using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour {

    public float maxHealth = 100;
    public float currentHealth;

    public Stat damage;
    public Stat armor;

    [Header ("Unity stuff")]
    public Image healthBar;
    public Text healthText;

    private void Awake()
    {
        currentHealth = maxHealth;
        healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {
        //Debug.Log("CS damage: " + transform.name + " Damage: " + damage);

        damage -= armor.getValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;

        Debug.Log(transform.name + " takes " + damage + " damage.");
        healthBar.fillAmount = currentHealth / maxHealth;
        healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    
    public virtual void Die()
    {
        Debug.Log(transform.name + " died"); //Die in some way
        //This method is meant to be ovewritten
    }

}
