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
    private Collider2D collider2D;

    // Others

    //private bool isIdle = true;

    private float defaultGravity;

    private bool isAlive = true;

    private bool isClimbing = false;

    // Use this for initialization
    void Start ()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        defaultGravity = rigidBody.gravityScale;

        //spriteRenderer = GetComponent<SpriteRenderer>();

        animator = GetComponent<Animator>();

        collider2D = GetComponent<Collider2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        MovePlayer();


    }

    private void MovePlayer()
    {
        MoveHorizontal();

        if (!Jump())
        {
            ClimbLadder();
        }

        //if (rigidBody.gravityScale >= defaultGravity)
        {
            //if (animator.GetBool("Climbing") == false)
            {
               
            }
        }

            /*
            if (!Jump())
            {

                ClimbLadder();
            }
            */
        
    }


    private void ClimbLadder()
    {
        bool isTouchingLadder = collider2D.IsTouchingLayers(LayerMask.GetMask("Ladder"));

        if (!isTouchingLadder)
        {
            // Reset default gravity
            rigidBody.gravityScale = defaultGravity;

            animator.SetBool("Climbing", false);

           

            return;
        }

        Debug.Log("Touching Ladder");

        //isClimbing = true;

        // turn off gravity, so stick on ladder
        rigidBody.gravityScale = 0.0f;
        //rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0f);

        // Check if user pressing left / right inputs
        float vert = CrossPlatformInputManager.GetAxis("Vertical");

        if (Mathf.Abs(vert) > minPlayerSpeed)
        {
            animator.SetBool("Climbing", true);

            Vector2 vel = rigidBody.velocity;

            vel.y = vert * climbSpeed * Time.deltaTime;

            rigidBody.velocity = vel;
        }
        else
        {
            //rigidBody.velocity = Vector2.zero;

            animator.SetBool("Climbing", false);
        }

    }

    private bool Jump()
    {
        bool isTouchingGround = collider2D.IsTouchingLayers(LayerMask.GetMask("Ground"));
        bool isTouchingLadder = collider2D.IsTouchingLayers(LayerMask.GetMask("Ladder"));

        if (!isTouchingGround || isTouchingLadder)
        //if (!isTouchingGround  ||  animator.GetBool("Climbing") == true)
        {
            return false;
        }

        //float vert = CrossPlatformInputManager.GetAxis("Vertical");

        bool isJump = CrossPlatformInputManager.GetButtonDown("Jump");

            //if (vert >= minPlayerSpeed)
            if (isJump)
            {
                //rigidBody.gravityScale = defaultGravity;

                //rigidBody.AddForce(new Vector2(0f, 10f));
                Vector2 jumpVelocity = new Vector2(0f, jumpSpeed);

                rigidBody.velocity += jumpVelocity;

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
