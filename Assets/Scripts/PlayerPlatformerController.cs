using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerPlatformerController : PhysicsObject {

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;
    public static int count;
    public static bool moving;
    public static bool gula1, gula2, gula3;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    enum CurrentStage
    {
        ganancia,
        luxuria,
        ira,
        orgulho,
        inveja,
        gula,
        preguica
    }
    [SerializeField]
    CurrentStage currentstage;
    // Use this for initialization
    void Start () {
        count = 0;
        moving = false;
        gula1 = false;
        gula2 = false;
        gula3 = false;
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
        switch (currentstage)
        {
            case CurrentStage.ganancia:
                if (other.gameObject.CompareTag("Moeda"))
                {
                    other.gameObject.SetActive(false);
                    count++;
                }
                if (other.gameObject.CompareTag("Espinho"))
                {
                    SceneManager.LoadScene("Fase01");
                }
                break;

            case CurrentStage.orgulho:
                if (other.gameObject.CompareTag("Espinho"))
                {
                    SceneManager.LoadScene("Fase01");
                }
                break;
            case CurrentStage.gula:
                if (other.gameObject.CompareTag("EspinhoGula"))
                {
                    Vector3 vetor = new Vector3(-5f, 0.06f, 0);
                    transform.position = vetor;
                    gula1 = true;
                    EspinhoGula.muda = true;
                }
                else if(other.gameObject.CompareTag("EspinhoGula2"))
                {
                    Vector3 vetor = new Vector3(-5f, 0.06f, 0);
                    transform.position = vetor;
                    gula2 = true;
                    EspinhoGula2.muda = true;
                }
                else if(other.gameObject.CompareTag("EspinhoGula3"))
                {
                    Vector3 vetor = new Vector3(-5f, 0.06f, 0);
                    transform.position = vetor;
                    gula3 = true;
                    EspinhoGula3.muda = true;
                    
                }
                
                else if(other.gameObject.CompareTag("Espinho"))
                {
                    SceneManager.LoadScene("Fase06");
                }
                break;
            default:
                if (other.gameObject.CompareTag("Espinho"))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
                break;
        }
    }
    /*public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Inimigo")
        {
            switch (currentstage)
            {
                case CurrentStage.luxuria:
                    SceneManager.LoadScene("Fase02");
                    break;
                case CurrentStage.ira:
                    SceneManager.LoadScene("Fase03");
                    break;
                default:
                    break;
            }
        }
    }*/

}
