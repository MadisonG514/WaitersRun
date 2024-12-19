using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; 
    public float jumpForce = 10f; 
  
    private Rigidbody2D rb;
    private bool isGrounded;

    public string horizontalAxis; 
    public string jumpButton;   

    public Sprite idleSprite;  // Sprite for when the player is not jumping
    public Sprite jumpSprite; // Sprite for when the player is jumping

    private SpriteRenderer spriteRenderer;

    public AudioClip jumpSound;
    private AudioSource audioSource;
   

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Horizontal movement
        float move = Input.GetAxis(horizontalAxis) * moveSpeed;
        rb.velocity = new Vector2(move, rb.velocity.y);

        // Jumping
        if (Input.GetButtonDown(jumpButton) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            PlaySound(jumpSound);
        }

        if (!isGrounded)
        {
            spriteRenderer.sprite = jumpSprite;
        }
        else
        {
            spriteRenderer.sprite = idleSprite;
        }

        if (move > 0)
        {
            spriteRenderer.flipX = false; // Facing right
        }
        else if (move < 0)
        {
            spriteRenderer.flipX = true; // Facing left
        }
        
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
    
    private void PlaySound(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player is grounded
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    
}
