using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	private IInput input;
	private Rigidbody2D rb;

	[SerializeField] private float speed = 4f;

	private void OnEnable()
	{
		input = GetComponent<IInput>();
		rb = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		rb.velocity = input.move * speed;
	}
}
