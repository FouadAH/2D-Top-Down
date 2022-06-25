using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // A public variable that dictates the movement speed of our character. We can access and edit public variable from the inspector
    public float moveSpeed = 5f;

    // Health and MaxHealth integer variables used to determine and track the player's current health.
    [HideInInspector] public int health = 4;
    public int maxHealth = 4;

    // A private rigidbody field to store a reference to our Rigidbody2D component
    Rigidbody2D rigidbodyComponent;

    // A reference to the player's animator component. We'll use it to trigger diffrent animations based of user input
    Animator animator;

    // A reference to the our GameUI script
    GameUI gameUI;

    // A reference to the CinemachineImpulseSource component. Used to trigger screen shake events.
    CinemachineImpulseSource impulseSource;

    // A private Vector2 (x, y) field that stores the user movement input.
    Vector2 movementInput;

    // Start is called before the first frame update
    void Start()
    {
        // GetComponent allows us to access other components of this GameObject
        rigidbodyComponent = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        impulseSource = GetComponent<CinemachineImpulseSource>();

        // FindObjectOfType will look through the entire heirarchy to find the first loaded object that matches the type.
        // Please note that this function is very slow. It is not recommended to use this function every frame (Update, FixedUpdate...)
        gameUI = FindObjectOfType<GameUI>();

        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Attack();
        Flip();
    }

    // FixedUpdate is called at a fixes rate, independant of the current frame rate (FPS) 
    private void FixedUpdate()
    {
        movementInput.Normalize();
        rigidbodyComponent.MovePosition(rigidbodyComponent.position + movementInput * moveSpeed * Time.fixedDeltaTime);
    }

    // This function is responsible for moving the player.
    // It reads and stores user input to determine the current movement direction.
    void Movement()
    {
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");

        // Setting the Animator "speed" paramater to the current movemnent vector magnitude
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
        health++; // Shorthand for health = health + 1
        gameUI.UpdateHealthUI(1);
    }

    public void TakeDamage()
    {
        health--; // Shorthand for health = health - 1
        gameUI.UpdateHealthUI(-1);
        impulseSource.GenerateImpulse();
        CheckDeath();
    }

    void CheckDeath()
    {
        // Checking if health is less than OR equal to 0
        if(health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reloading the current active scene
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
