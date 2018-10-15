using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Move : MonoBehaviour
{

	private Rigidbody2D rbd;

	public float MoveSpeed = 25f;

	private void Awake()
	{
		rbd = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		float h = Input.GetAxis("Horizontal");

		MoveFunc(h);
	}

	private void MoveFunc(float _h)
	{
		rbd.AddForce(new Vector2(_h * MoveSpeed, 0f));
	}
}
