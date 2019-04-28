// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerMovement : MonoBehaviour
// {
// 	[SerializeField] private Animator animator;
// 	[SerializeField] private float speed = 4f;
// 	private float cooldown = 0.2f;

// 	private IInput input;
// 	private Rigidbody2D rb;
// 	private float timestamp;

// 	private void OnEnable()
// 	{
// 		input = GetComponent<IInput>();
// 		rb = GetComponent<Rigidbody2D>();
// 	}

// 	private void Update()
// 	{
// 		if (Time.time > timestamp)
// 		{
// 			if (input.move.magnitude > 0f)
// 			{
// 				Debug.Log("input.move " + input.move);

// 				if (Mathf.Abs(input.move.x) > Mathf.Abs(input.move.y))
// 				{
// 					transform.position += Vector3.right * Math.Sign(input.move.x);
// 					Debug.Log("move X " + Vector3.right * Math.Sign(input.move.x));
// 				}
// 				else
// 				{
// 					transform.position += Vector3.up * Math.Sign(input.move.y);
// 					Debug.Log("move X " + Vector3.up * Math.Sign(input.move.y));
// 				}

// 				// if (animator)
// 				// {
// 				// 	animator.SetTrigger("Move");
// 				// }
// 			}

// 			timestamp = Time.time + cooldown;
// 		}
// 	}
// }
