using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player2Controller : MonoBehaviour
{

	public float moveSpeed;
	public float jumpForce;


	private Rigidbody2D theRB;

	public Transform groundCheckPoint;
	public float groundCheckRadius;
	public LayerMask whatIsGround;

	public bool isGrounded;

	private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();

		anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		
		/*
		var dirX = CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed;
		
		isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);
		
        if(dirX < 0)
		{
			theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
		}else if(dirX > 0)
		{
			theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
		}else {
			theRB.velocity = new Vector2(0, theRB.velocity.y);
		}

		if(CrossPlatformInputManager.GetButtonDown("Jump") && isGrounded)
		{
			theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
		}

		if(theRB.velocity.x < 0) {
			transform.localScale = new Vector3(-0.35f, 0.35f, 0.35f);
		} else if(theRB.velocity.x > 0)
		{
			transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
		}

		anim.SetFloat("Speed", Mathf.Abs(theRB.velocity.x));
		anim.SetBool("Grounded", isGrounded);
*/
    }
}
