using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private float moveForce = 10f;

    [SerializeField]
    private float jumpForce = 12f;

    private float movementX;
    private Rigidbody2D mybody;
    private SpriteRenderer sr;
    private Animator anim;
    private string WALK_ANIMATION = "Walk";
    private string GROUND_TAG = "Ground";
    private string ENEMY_TAG = "Enemy";

    private bool isGrounded = true;

    void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
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
        // movementX value = [-1, 0, 1]
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0.0f, 0.0f) * Time.deltaTime * moveForce;
    }

    void AnimatePlayer()
    {
        // Going to the right
        if (movementX > 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }
        // Going to the left 
        else if (movementX < 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
        else// Stading 
        {
            anim.SetBool(WALK_ANIMATION, false); 
        }
    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            mybody.AddForce(new Vector2(0.0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ENEMY_TAG)){
            Destroy(gameObject);
        }
    }
}
