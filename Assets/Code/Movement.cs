using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	[SerializeField] private Animator _animator;
	[SerializeField] private float _defaultSpeed = 4f;
	private float _speed;

	public float Speed => _speed;

	private IInput _input;
	private Rigidbody2D _rb;

	private void OnEnable()
	{
		_input = GetComponent<IInput>();
		_rb = GetComponent<Rigidbody2D>();

		SetDefaultSpeed();
	}

	private void Update()
	{
		_rb.velocity = _input.Move * _speed;

		if (_animator)
		{
			var renderer = _animator.GetComponent<SpriteRenderer>();
			if (renderer && _rb.velocity.magnitude > 0f)
			{
				renderer.flipX = _rb.velocity.x < 0f;
			}
		}
	}

	public void SetSpeed(float newSpeed)
	{
		_speed = newSpeed;
	}

	public void SetDefaultSpeed()
	{
		_speed = _defaultSpeed;
	}
}
