using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPlatformerController : PhysicsObject {

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;
    public static int count;
    public static bool moving;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    // Use this for initialization
	void Start () {
        count = 0;
        moving = false;
	}

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;
        move.x = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpTakeOffSpeed;
        } else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
                velocity.y = velocity.y * 0.5f;
        }

        bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < -0.01f));
        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
        if (move.x > 0.1f || move.x < -0.01f)
        {
            moving = true;
            animator.SetBool("moving", true);
        } else
        {
            moving = false;
            animator.SetBool("moving", false);
        }
        targetVelocity = move * maxSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Espinho"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if(other.gameObject.CompareTag("Moeda"))
        {
            other.gameObject.SetActive(false);
            count++;
        }
    }
}
