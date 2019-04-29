using System;
using UnityEngine;

public class PatrolState : BaseState
{
	private Chicken _chicken;
	private int _currentIndex;
	private bool _scared;
	private const float _stopDistance = 0.1f;

	public PatrolState(Chicken chicken) : base(chicken.gameObject)
	{
		this._chicken = chicken;
	}

	public override void OnStart()
	{
		_scared = false;
		_chicken.SetTarget(_chicken.Waypoints[0]);

		CollisionEventBroadcaster.TriggerEnterAction += OnTriggerEnter;
	}

	public override Type Tick()
	{
		var distance = _chicken.Target.position - transform.position;
		_chicken.Input.SetMove(distance.normalized);

		// If close enough, move to next waypoint.
		if (distance.magnitude < _stopDistance)
		{
			_currentIndex = (_currentIndex + 1) % _chicken.Waypoints.Count;
			_chicken.SetTarget(_chicken.Waypoints[_currentIndex]);
		}

		if (_scared)
		{
			_chicken.Input.SetMove(Vector2.zero);
			return typeof(FleeState);
		}

		return null;
	}

	public override void OnEnd()
	{
		CollisionEventBroadcaster.TriggerEnterAction -= OnTriggerEnter;
	}

	private void OnTriggerEnter(TriggerEnterData data)
	{
		if (data.source != transform || !data.other.CompareTag("Player")) { return; }

		if (_chicken.FleeDestination)
		{
			_scared = true;
		}
	}
}
