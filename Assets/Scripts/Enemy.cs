using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Config
    [SerializeField] float runSpeed;

    private Rigidbody2D rigidBody;

    private CapsuleCollider2D bodyCollider2D;
    private BoxCollider2D feetCollider2D;
    private EdgeCollider2D edgeCollider2D;

    private bool isTouchingGround = false;

    // Use this for initialization
    void Start ()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        bodyCollider2D = GetComponent<CapsuleCollider2D>();
        feetCollider2D = GetComponent<BoxCollider2D>();
        edgeCollider2D = GetComponent<EdgeCollider2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        bool isTouchingWall   = edgeCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground"));
        bool isTouchingGround = feetCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground"));

        if (isTouchingWall || !isTouchingGround)
        {
            FlipSprite();
        }

        MoveEnemy();    
    }

    /*
    private void OnTriggerExit2D(Collider2D collision)
    {
        FlipSprite();       
    }
    */

    private void MoveEnemy()
    {
        Vector2 vel = rigidBody.velocity;

        vel.x = runSpeed * Time.deltaTime;

        rigidBody.velocity = vel;

    }

    // !! From the course !! Hz can be input / or velocity as in course
    private void FlipSprite()
    {
        runSpeed = -runSpeed;

        bool enemyHasHorizVelocity = Mathf.Abs(runSpeed) > Mathf.Epsilon;

        if (enemyHasHorizVelocity)
        {
            transform.localScale = new Vector2(Mathf.Sign(runSpeed), 1f);
        }
    }

}
