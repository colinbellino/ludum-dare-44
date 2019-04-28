using System;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class ChickenAI : MonoBehaviour, IInput
{
	private const float stopDistance = 0.1f;
	private Transform owner;
	public Vector2 move { get; private set; }
	private float speedingFlee = 8.5f;
	private float maxFleeDistance = 5f;
	private bool isFleeing = false;
	private Vector3 fleeDirection;
	private Vector3 fleeOriginalPosition;

	[SerializeField] private Transform[] waypoints;
	private int currentIndex;

	private void OnEnable()
	{
		owner = GetComponent<Transform>();

		if (waypoints.Length < 1)
		{
			Debug.LogWarning("Missing waypoints.");
		}
	}

	private void Update()
	{
		if (isFleeing)
		{
			var distance = fleeOriginalPosition - transform.position;
			if (distance.magnitude < maxFleeDistance)
			{
				move = -fleeDirection.normalized;
			}
			else
			{
				isFleeing = false;
				GetComponent<Movement>().SetDefaultSpeed();
			}
		}
		else if (waypoints.Length > 0)
		{
			var destination = waypoints[currentIndex];
			var distance = destination.position - owner.position;
			move = distance.normalized;

			if (distance.magnitude < stopDistance)
			{
				NextWaypoint();
			}
		}

	}

	private void NextWaypoint()
	{
		currentIndex = (currentIndex + 1) % waypoints.Length;
	}

	public void FleeFromTarget(Vector3 targetPosition)
	{
		Debug.Log("I must Flee kwak => ");
		isFleeing = true;
		fleeOriginalPosition = transform.position;
		fleeDirection = (targetPosition - fleeOriginalPosition);
		GetComponent<Movement>().SetSpeed(speedingFlee);
	}
}
