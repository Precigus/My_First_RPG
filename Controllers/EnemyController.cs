using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

    public float lookRadius = 10f;
    public float attackDistance = 5f;

    Transform target;
    NavMeshAgent agent;
    CharacterCombat combat;
    public Animator anim;

	// Use this for initialization
	void Start () {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        combat = GetComponent<CharacterCombat>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        float distance = Vector3.Distance(target.position, transform.position);
        //anim.SetBool("isIdle", false);
        if (distance <= lookRadius)
        {
            //Inserted movement trial
            FaceTarget();
            //this.transform.Translate(0, 0, 0.05f);
            //Inserted movement trial

            agent.SetDestination(target.position);
            

            anim.SetBool("isIdle", false);
            anim.SetBool("isWalking", true);
            anim.SetBool("isAttacking", false);

            if (distance <= agent.stoppingDistance) //attackDistance
            {
                // Face target
                FaceTarget();
                
                
                    // Attack target
                    CharacterStats targetStats = target.GetComponent<CharacterStats>();
                if (targetStats != null)
                {
                    agent.isStopped = true;
                    anim.SetBool("isWalking", false);
                    anim.SetBool("isAttacking", true);

                    //combat.Attack(targetStats);
                }
                agent.isStopped = false;
            }
            //else
            //{
            //    anim.SetBool("isWalking", true);
            //    anim.SetBool("isAttacking", false);
            //}
        }
        else
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isAttacking", false);

        }

    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        this.transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

        //Switch between animations
        //animator.SetBool("isIdle", false);
        //if (direction.magnitude > lookRadius)
        //{
        //    this.transform.Translate(0, 0, 0.05f);
        //    animator.SetBool("isWalking", true);
        //    animator.SetBool("isAttacking", false);
        //}
        //else
        //{
        //    animator.SetBool("isAttacking", true);
        //    animator.SetBool("isWalking", false);
        //}
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    
}
