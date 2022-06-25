using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //A public variable that dictates the movement speed of our character. We can access and edit public variable from the inspector
    public float moveSpeed = 5f;

    [HideInInspector] public int health = 4;
    public int maxHealth = 4;

    //A private rigidbody field to store a reference to our Rigidbody2D component
    Rigidbody2D rigidbodyComponent;

    Animator animator;

    GameUI gameUI;

    CinemachineImpulseSource impulseSource;

    //A private Vector2 field that stores the user movement input.
    Vector2 movementInput;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        gameUI = FindObjectOfType<GameUI>();
        impulseSource = GetComponent<CinemachineImpulseSource>();

        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Attack();
        Flip();
    }

    private void FixedUpdate()
    {
        movementInput.Normalize();
        rigidbodyComponent.MovePosition(rigidbodyComponent.position + movementInput * moveSpeed * Time.fixedDeltaTime);
    }

    void Movement()
    {
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("speed", movementInput.sqrMagnitude);
    }

    void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Attack");
        }
    }

    public void Heal()
    {
        health++;
        gameUI.UpdateHealthUI(1);
    }

    public void TakeDamage()
    {
        health--;
        gameUI.UpdateHealthUI(-1);
        impulseSource.GenerateImpulse();
        CheckDeath();
    }

    void CheckDeath()
    {
        if(health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void Flip()
    {
        if (movementInput.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 0);
        }
        else if(movementInput.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 0);
        }
    }
}
