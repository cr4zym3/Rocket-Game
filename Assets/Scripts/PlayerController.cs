using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float bootsForce = 5f;
    private Rigidbody2D rb;
    private float horizontalInput;
    private bool facingRight = true;
    public bool isGrounded = false;
    public bool canUseBoots = false;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public ParticleSystem rocketBoots;
    public float fuel;
    public float health = 5f;
    public ParticleSystem bloodExplosion;
    private Heart heart;

    void Start()
    {
        heart = GetComponent<Heart>();
        rb = GetComponent<Rigidbody2D>();
        fuel = 100f;
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput < 0 && facingRight)
        {
            facingRight = false;
            Flip();
        }
        if (horizontalInput > 0 && !facingRight)
        {
            facingRight = true;
            Flip();
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
            canUseBoots = false;
        }
        if (Input.GetKeyUp(KeyCode.Space) && !isGrounded)
        {
            canUseBoots = true;
            rb.gravityScale = 0.75f;
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (isGrounded)
        {
            rb.gravityScale = 0.75f;
            canUseBoots = false;
            rocketBoots.Stop();
        }
        if (!isGrounded && rb.velocity.y < 0f)
        {
            canUseBoots = true;
        }

        if (canUseBoots && fuel > 0f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rocketBoots.Play();
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                rocketBoots.Stop();
            }
        }

        if (fuel <= 0f)
        {
            fuel = 0f;
            canUseBoots = false;
            rocketBoots.Stop();
            rb.gravityScale = 0.75f;
        }

        if (fuel >= 100f)
        {
            fuel = 100f;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        if (Input.GetKey(KeyCode.Space) && canUseBoots)
        {
            rb.gravityScale = 0f;
            RocketBoots();
        }

        if (isGrounded && fuel < 100f)
        {
            fuel += 1f;
        }
    }

    public void Flip()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);
    }

    void Jump()
    {
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
    }

    void RocketBoots()
    {
        Vector2 forceDirection = transform.up;
        rb.AddForce(forceDirection * bootsForce, ForceMode2D.Force);
        fuel -= 1f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject, 0.5f);
            other.gameObject.GetComponent<EnemyScript>().killed = true;
            rb.AddForce(new Vector2(0f, jumpForce * 0.5f), ForceMode2D.Impulse);
            other.gameObject.transform.localScale = new Vector3(2, 1, 2);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !collision.gameObject.GetComponent<EnemyScript>().killed)
        {
            DamagePlayer();
        }
        else if (collision.gameObject.CompareTag("Spikes"))
        {
            DamagePlayer();
        }
    }

    public void DamagePlayer()
    {
        health--;
        Instantiate(bloodExplosion, transform.position, transform.rotation);
        heart.UpdateHealth(health);
        if (health == 0)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }
}
