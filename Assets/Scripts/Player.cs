using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    // Config
    [SerializeField] float runSpeed;
    [SerializeField] float climbSpeed;

    [SerializeField] float minPlayerSpeed;

    [SerializeField] float jumpSpeed;

    // Cached
    private Rigidbody2D rigidBody;
    // private SpriteRenderer spriteRenderer;
    private Animator animator;

    private CapsuleCollider2D bodyCollider2D;
    private Collider2D feetCollider2D;

    // Others

    //private bool isIdle = true;

    private float defaultGravity;

    private bool isAlive = true;

    private bool isClimbing = false;

    private bool hasJumped = false;

    bool isTouchingGround = false;
    bool isTouchingLadder = false;

    bool waitForLand = false;

    // Use this for initialization
    void Start ()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        defaultGravity = rigidBody.gravityScale;

        //spriteRenderer = GetComponent<SpriteRenderer>();

        animator = GetComponent<Animator>();

        bodyCollider2D = GetComponent<CapsuleCollider2D>();

        feetCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
 


    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        MovePlayer();


    }

    private void MovePlayer()
    {
        isTouchingGround = feetCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground"));
        isTouchingLadder = feetCollider2D.IsTouchingLayers(LayerMask.GetMask("Ladder"));

        if (!Jump())
        {
            if (!ClimbLadder())
            {
                //MoveHorizontal();
            }
        }

        MoveHorizontal();

        if (waitForLand && isTouchingGround)
        {
            hasJumped = false;
            waitForLand = false;

            //animator.SetBool("Rolling", true);

            Debug.Log("Landed");
        }

        if (rigidBody.velocity.y < 0f && hasJumped)
        {
            waitForLand = true;
        }

    }


    private bool ClimbLadder()
    {
        //isTouchingLadder = collider2D.IsTouchingLayers(LayerMask.GetMask("Ladder"));

        if (!isTouchingLadder)
        {
            // Reset default gravity
            rigidBody.gravityScale = defaultGravity;

            animator.SetBool("Climbing", false);

            return false;
        }

        animator.SetBool("Climbing", true);

        //Debug.Log("Touching Ladder");

        //isClimbing = true;

        // turn off gravity, so stick on ladder
        rigidBody.gravityScale = 0.0f;
        //rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0f);

        // Check if user pressing left / right inputs
        float vert = CrossPlatformInputManager.GetAxis("Vertical");

        if (Mathf.Abs(vert) > minPlayerSpeed)
        {
            //Debug.Log("Climbing Ladder");

            //animator.SetBool("Climbing", true);

            Vector2 vel = rigidBody.velocity;

            vel.y = vert * climbSpeed * Time.deltaTime;

            rigidBody.velocity = vel;
        }
        else
        {
            //rigidBody.velocity = Vector2.zero;

            //animator.SetBool("Climbing", false);
        }

        return true;
    }

    private bool Jump()
    {
        //isTouchingGround = collider2D.IsTouchingLayers(LayerMask.GetMask("Ground"));
        //isTouchingLadder = collider2D.IsTouchingLayers(LayerMask.GetMask("Ladder"));

        if (!isTouchingGround || isTouchingLadder)
        //if (!isTouchingGround  ||  animator.GetBool("Climbing") == true)
        {

            //animator.SetBool("Jumping", true);

            return false;          
        }

        //float vert = CrossPlatformInputManager.GetAxis("Vertical");

        bool isJump = CrossPlatformInputManager.GetButtonDown("Jump");

        //if (vert >= minPlayerSpeed)
        if (isJump)
        {
            Debug.Log("Jumped");

            //animator.SetBool("Jumping", true);

            //rigidBody.gravityScale = defaultGravity;

            //rigidBody.AddForce(new Vector2(0f, 10f));
            Vector2 jumpVelocity = new Vector2(0f, jumpSpeed);

            rigidBody.velocity += jumpVelocity;

            hasJumped = true;

            return true;
        }

        return false;
    }

    private void MoveHorizontal()
    {
        // Check if user pressing left / right inputs
        float hz = CrossPlatformInputManager.GetAxis("Horizontal");

        FlipSprite(hz);

        Vector2 vel = rigidBody.velocity;

        vel.x = hz * runSpeed * Time.deltaTime;

        rigidBody.velocity = vel;

        //
        //Debug.Log(vel);

        //
        bool hasHorizontalSpeed = (Mathf.Abs(vel.x) > Mathf.Epsilon);

        animator.SetBool("Running", hasHorizontalSpeed);

    }

    // !! From the course !! Hz can be input / or velocity as in course
    private void FlipSprite(float hz)
    {
        bool playerHasHorizVelocity = Mathf.Abs(hz) > Mathf.Epsilon;

        if (playerHasHorizVelocity)
        {
            transform.localScale = new Vector2(Mathf.Sign(hz), 1f);
        }
    }

}
