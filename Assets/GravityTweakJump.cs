using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityTweakJump : MonoBehaviour 
{
	// Jump parms
	private Rigidbody2D rbd;
	public float jumpForce = 3f;
	public float jumpTime = .5f;

	public AnimationCurve gravityCurve;
	
	// Checking to see where the ground is...
	private bool _isGrounded = false;
	public Transform groundRef;
	public float collisionRadius = 1f;
	public LayerMask whatIsGround;

	// Jump logic - am I currently jumping or holding down Jump?
	private bool isJumping = false;
	private bool jumpButtonPressed = false;

	// Use this for initialization
	void Awake ()
	{
		rbd = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Am I on the ground - true or false?
		_isGrounded = Physics2D.OverlapCircle(groundRef.position, collisionRadius, whatIsGround);
		
		
		// A one frame input starts the jump if able...
		if (Input.GetKeyDown(KeyCode.Space) && _isGrounded && !isJumping)
		{
			
			jumpButtonPressed = true;
			
			// If i'm on the ground, and not currently jumping - start the Jump Coroutine
			StartCoroutine(Jump());
		}
		
		// This flips a boolean switch for every frame the space button is pressed whilst jumping
		if (Input.GetKey(KeyCode.Space) && isJumping)
		{
			jumpButtonPressed = true;
		}
		else
		{
			jumpButtonPressed = false;
		}
		
	}

	IEnumerator Jump()
	{
		float t = 0;

		isJumping = true;

		while (jumpButtonPressed && t < jumpTime)
		{
			float pct = gravityCurve.Evaluate(t / jumpTime);
			rbd.gravityScale = pct;
			
			t += Time.fixedDeltaTime;
			//Debug.Log(pct);
			yield return new WaitForFixedUpdate();
			
		}

		isJumping = false;
		rbd.gravityScale = 5f;

	}
}
