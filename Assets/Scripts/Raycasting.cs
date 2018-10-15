using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions.Comparers;

public class Raycasting : MonoBehaviour

{
	public float upLen = 1f;
	public float downLen = 1f;
	public float leftLen = 1f;
	public float rightLen = 1f;

	public LayerMask ground;

	public Text downReport;

	private Rigidbody2D rbd;
	public float moveMulti = 1f;
	public float maxSpeed = 10f;

	// Use this for initialization
	void Awake ()
	{
		rbd = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		float h = Input.GetAxis("Horizontal");
		
		rbd.AddForce(Vector2.right * h * moveMulti);

		float speed = rbd.velocity.sqrMagnitude;

		Debug.Log(speed);

		if (speed > maxSpeed)
		{
			
		}



		CastRays();
		DrawDebugRays();


		

	}

	private void DrawDebugRays()
	{
		Debug.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y + upLen));
		Debug.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - downLen));
		Debug.DrawLine(transform.position, new Vector2(transform.position.x + leftLen, transform.position.y));
		Debug.DrawLine(transform.position, new Vector2(transform.position.x - rightLen, transform.position.y));
		
	}

	private void CastRays()
	{
		RaycastHit2D upRay = Physics2D.Raycast(transform.position, Vector2.up, upLen, ground);
		RaycastHit2D downRay = Physics2D.Raycast(transform.position, Vector2.down, downLen, ground);
		RaycastHit2D leftRay = Physics2D.Raycast(transform.position, Vector2.left, leftLen, ground);
		RaycastHit2D rightRay = Physics2D.Raycast(transform.position, Vector2.right, rightLen, ground);
	}
}
