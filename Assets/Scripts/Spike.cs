using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    // When a GameObject collides with another GameObject, Unity calls OnTriggerEnter when two GameObjects collide.
    // Note: Both GameObjects must contain a Collider component. One must have Collider.isTrigger enabled, and contain a Rigidbody.
    // If both GameObjects have Collider.isTrigger enabled, no collision happens. The same applies when both GameObjects do not have a Rigidbody component.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Checking if the tag of the colliding GameObject is equal to "Player"
        if(collision.CompareTag("Player"))
        {
            //Calling the TakeDamage function of the PlayerController script
            collision.GetComponent<PlayerController>().TakeDamage();
        }
    }
}
