using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int health = 3;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void TakeDamage(int damageDealt)
    {
        //Debug.Log("Ouch");
        animator.SetTrigger("Hit");

        health-= damageDealt; // Shorthand for health = health - damageDealt
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Checking if the colliding object has a PlayerContoller script
        if (collision.GetComponent<PlayerController>() != null)
        {
            collision.GetComponent<PlayerController>().TakeDamage();
        }

        //Checking if the colliding object has a Weapon script
        if (collision.GetComponent<Weapon>() != null)
        {
            //Calling the TakeDamage function and passing the weapons damage value
            TakeDamage(collision.GetComponent<Weapon>().damage);
        }
    }
}
