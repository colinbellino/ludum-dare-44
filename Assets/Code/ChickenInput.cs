using System;
using UnityEngine;

public class ChickenInput : MonoBehaviour, IInput
{
	private const float stopDistance = 0.1f;
	private Transform owner;
	public Vector2 move { get; private set; }

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
		if (waypoints.Length > 0)
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
}
