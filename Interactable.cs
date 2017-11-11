﻿using UnityEngine;

public class Interactable : MonoBehaviour {

    public float radius = 4f;
    public Transform interactionTransform;

    bool isFocus = false;
    Transform player;


    bool hasInteracted = false;

    public virtual void Interact()
    {
        // This method is meant to be overwritten
        //Debug.Log("Interacting with " + transform.name);
    }
    

    void Update()
    {
        if (isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if (distance <= radius)
            {       
                    Interact();
                    hasInteracted = true;
                
            }
        }
    }

    public void OnFocus (Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDefocus()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }
        

    private void OnDrawGizmosSelected()
    {
        if(interactionTransform == null)
        {
            interactionTransform = transform;
        }

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);

    }

    public virtual void Die()
    {

    }
}
