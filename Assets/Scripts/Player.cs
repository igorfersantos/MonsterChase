using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D playerBody;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private const string WALK_ANIMATION = "Walk";
    private const string GROUND_TAG = "Ground";
    private const string ENEMY_TAG = "Enemy";

    [SerializeField]
    private float moveForce = 10f;

    [SerializeField]
    private float jumpForce = 11f;

    private float movementX;
    private float difficultyMultiplier = 1f;

    private bool isGrounded;

    private void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        PlayerJump();
    }

    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += (new Vector3(movementX, 0f, 0f) * moveForce * difficultyMultiplier) * Time.deltaTime;
    }

    void FixedUpdate()
    {
        PlayerJump();
    }

    void AnimatePlayer()
    {
        if (movementX > 0)
        {
            animator.SetBool(WALK_ANIMATION, true);
            spriteRenderer.flipX = false;
        }
        else if (movementX < 0)
        {
            animator.SetBool(WALK_ANIMATION, true);
            spriteRenderer.flipX = true;
        }
        else
        {
            animator.SetBool(WALK_ANIMATION, false);
        }

    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            playerBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
        }

        if (other.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
    }
}
