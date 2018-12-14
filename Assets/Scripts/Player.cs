using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    [SerializeField] float playerSpeed;
    [SerializeField] float minPlayerSpeed;

    //

    private Rigidbody2D rigidBody;
   // private SpriteRenderer spriteRenderer;
    private Animator animator;

    //private bool faceRight = true; // default

    private bool isIdle = true;

    // Use this for initialization
    void Start ()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        //spriteRenderer = GetComponent<SpriteRenderer>();

        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        MovePlayer();


    }

    private void MovePlayer()
    {
        MoveHorizontal();

        MoveVertical();
    }

    private void MoveVertical()
    {
        float vert = CrossPlatformInputManager.GetAxis("Vertical");

        if (vert >= minPlayerSpeed)
        {
            rigidBody.AddForce(new Vector2(0f, 10f));
        }

    }

    private void MoveHorizontal()
    {
        isIdle = true;

        float hz = CrossPlatformInputManager.GetAxis("Horizontal");

        // Check if user pressing left / right inputs
        if (Mathf.Abs(hz) > minPlayerSpeed)
        {
            //faceRight = true;
            isIdle = false;
        }

        FlipSprite(hz);
     
        if (!isIdle)
        {
            Vector2 vel = rigidBody.velocity;

            vel.x = hz * playerSpeed * Time.deltaTime;

            rigidBody.velocity = vel;

            animator.SetBool("Running", true);
        }
        else
        {
            animator.SetBool("Running", false);
            //animator.SetBool("Idle", true);
        }
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
