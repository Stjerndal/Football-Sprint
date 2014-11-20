using UnityEngine;

public class PlatformerCharacter2D : MonoBehaviour 
{
	bool facingRight = true;							// For determining which way the player is currently facing.

	[SerializeField] float maxSpeed = 10f;				// The fastest the player can travel in the x axis.
	[SerializeField] float jumpForce = 800f;			// Amount of force added when the player jumps.	
	

	[SerializeField] bool airControl = false;			// Whether or not a player can steer while jumping;
	[SerializeField] LayerMask whatIsGround;			// A mask determining what is ground to the character
	
	Transform groundCheck;								// A position marking where to check if the player is grounded.
	float groundedRadius = .2f;							// Radius of the overlap circle to determine if grounded
	bool grounded = false;								// Whether or not the player is grounded.
	Transform ceilingCheck;								// A position marking where to check for ceilings
	float ceilingRadius = .4f;							// Radius of the overlap circle to determine if the player can stand up
	Animator anim;										// Reference to the player's animator component.

	bool doubleJumped = false;
	bool roofed = false;

	public bool dead = false;

	PlayerAudio playerAudio;

	Vector2 velocity2;

    void Awake()
	{
		// Setting up references.
		groundCheck = transform.Find("GroundCheck");
		ceilingCheck = transform.Find("CeilingCheck");
		playerAudio = GameObject.FindObjectOfType<PlayerAudio>();
//		playerAudio = GetComponentInParent<PlayerAudio>();
		anim = GetComponent<Animator>();
		velocity2.x = maxSpeed;//Always move right
	}


	void FixedUpdate()
	{
		if(!dead) {
			// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
			grounded = Physics2D.OverlapCircle(groundCheck.position, groundedRadius, whatIsGround);
			anim.SetBool("Ground", grounded);

			roofed = Physics2D.OverlapCircle(ceilingCheck.position, ceilingRadius, whatIsGround);
			if(roofed) {
				rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, -1f);
				roofed = false;
			}

			// Set the vertical animation
			anim.SetFloat("vSpeed", rigidbody2D.velocity.y);

			if(grounded) {
				doubleJumped = false;
				playerAudio.Run ();
			} else {
				playerAudio.RunStop();
			}
			anim.SetBool("DoubleJumped", doubleJumped);
		}
	}


	public void Move(float move, bool jump)
	{

		//only control the player if grounded or airControl is turned on
		if(grounded || airControl)
		{

			// The Speed animator parameter is set to the absolute value of the horizontal input.
			anim.SetFloat("Speed", Mathf.Abs(move));

			velocity2.y = rigidbody2D.velocity.y;
			rigidbody2D.velocity = velocity2;

			// Move the character
			//rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);
			
			// If the input is moving the player right and the player is facing left...
			if(move > 0 && !facingRight)
				// ... flip the player.
				Flip();
			// Otherwise if the input is moving the player left and the player is facing right...
			else if(move < 0 && facingRight)
				// ... flip the player.
				Flip();
		}

        // If the player should jump...
        if ((grounded || !doubleJumped) && jump) {
			if(!grounded) {
				doubleJumped = true;
				playerAudio.DoubleJump();
			} else {
				playerAudio.Jump();
			}
            // Add a vertical force to the player.
            anim.SetBool("Ground", false);

			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0);

            rigidbody2D.AddForce(new Vector2(0f, jumpForce));


        }
	}

	
	void Flip ()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
