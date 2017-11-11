using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasing : MonoBehaviour {

    public Transform player;
    static Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
        if(Vector3.Distance(player.position, this.transform.position) < 10)
        {
            Vector3 direction = player.position - this.transform.position;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

            animator.SetBool("isIdle", false);
            if(direction.magnitude > 5)
            {
                this.transform.Translate(0, 0, 0.05f);
                animator.SetBool("isWalking", true);
            }
        }
	}
}
