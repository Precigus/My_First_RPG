using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats {

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            TakeDamage(5);
        }
    }

    public override void Die()
    {
        base.Die();

        // Add ragdoll effect // die animation
        //add timer

        Destroy(gameObject);
    }

}
