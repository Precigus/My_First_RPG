using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class Enemy : Interactable {

    //PlayerManager playerManager;
    //CharacterStats myStats;
    Animator anim;


    private void Start()
    {

    }


    public override void Interact()
    {
        base.Interact();
        attackAnim();

        }
    public override void Die()
    {
        base.Die();
        //anim.SetBool("isDying", true);
    }

    public void attackAnim()
    {
        GameObject playerAnimator = GameObject.Find("Player");
        CharacterAnimator charAnim = playerAnimator.GetComponent<CharacterAnimator>();
        charAnim.animator.SetTrigger("attack");
    }

}
