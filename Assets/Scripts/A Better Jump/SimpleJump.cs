using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleJump : MonoBehaviour
{
	private Rigidbody2D _rbd;
	public float jumpForce = 50f;

	private bool _isGrounded = false;
	public Transform groundRef;
	public float collisionRadius = 1f;
	public LayerMask whatIsGround;

	// Use this for initialization
	private void Awake ()
	{
		_rbd = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	private void FixedUpdate ()
	{
		_isGrounded = Physics2D.OverlapCircle(groundRef.position, collisionRadius, whatIsGround);
		
		
		
		if (Input.GetKey(KeyCode.Space) && _isGrounded)
		{
			_rbd.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
		}

	}

	
	// This helper function displays a sphere at our characters feet so we can see the groundcheck radius
	private void OnDrawGizmos()
	{
		Gizmos.DrawSphere(groundRef.position, collisionRadius);
		
	}

	
}
