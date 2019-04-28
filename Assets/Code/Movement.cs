using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	[SerializeField] private Animator animator;
	[SerializeField] private float defaultSpeed = 4f;
	private float speed;

	private IInput input;
	private Rigidbody2D rb;

	private void OnEnable()
	{
		SetDefaultSpeed();
		input = GetComponent<IInput>();
		rb = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		rb.velocity = input.move * speed;

		if (animator)
		{
			var renderer = animator.GetComponent<SpriteRenderer>();
			if (renderer && rb.velocity.magnitude > 0f)
			{
				renderer.flipX = rb.velocity.x < 0f;
			}
		}
	}

	public void SetSpeed(float newSpeed)
	{
		speed = newSpeed;
	}

	public void SetDefaultSpeed()
	{
		speed = defaultSpeed;
	}
}
