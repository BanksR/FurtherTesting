using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABetterJump : MonoBehaviour
{
	
	// Jump parms
	private Rigidbody2D _rbd;
	public float jumpForce = 3f;
	public float jumpTime = .5f;
	
	// Checking to see where the ground is...
	private bool _isGrounded = false;
	public Transform groundRef;
	public float collisionRadius = 1f;
	public LayerMask whatIsGround;

	// Jump logic - am I currently jumping or holding down Jump?
	private bool _isJumping = false;
	private bool _jumpButtonPressed = false;

	// Use this for initialization
	private void Awake()
	{
		_rbd = GetComponent<Rigidbody2D>();
	}

	
	
	// Update is called once per frame
	private void Update ()
	{
		// Am I on the ground - true or false?
		_isGrounded = Physics2D.OverlapCircle(groundRef.position, collisionRadius, whatIsGround);
		
		
		// A one frame input starts the jump if able...
		if (Input.GetKeyDown(KeyCode.Space) && _isGrounded && !_isJumping)
		{
			
			_jumpButtonPressed = true;
			
			// If i'm on the ground, and not currently jumping - start the Jump Coroutine
			StartCoroutine(Jump());
		}
		
		// This flips a boolean switch for every frame the space button is pressed whilst jumping
		if (Input.GetKey(KeyCode.Space) && _isJumping)
		{
			_jumpButtonPressed = true;
		}
		else
		{
			_jumpButtonPressed = false;
		}
		

		
	}
	// This is our Jump Coroutine
	private IEnumerator Jump()
	{
		
		// If we're here, we're jumping so set isJumping to true
		_isJumping = true;
		
		// t is a timer variable
		var t = 0f;

		
		// This while loop keeps going until either the player releases
		// the space key, or the timer reaches jumpTime
		while (_jumpButtonPressed && t < jumpTime)
		{
			
			Vector2 jumpVector = Vector2.Lerp(new Vector2(0f, jumpForce), Vector2.zero, t / jumpTime);
			_rbd.AddForce(jumpVector);
			t += Time.fixedDeltaTime;
			yield return new WaitForFixedUpdate();
			
		}

		_isJumping = false;
		//Debug.Log("Jump CoRoutine Finishes...");


	}
	
	
	
	// This helper function displays a sphere at our characters feet so we can see the groundcheck radius
	private void OnDrawGizmos()
	{
		Gizmos.DrawSphere(groundRef.position, collisionRadius);
	}


}
