using System;
using UnityEngine;

public class FleeState : BaseState
{
	private Chicken _chicken;
	private float _speedModifier;
	private const float _stopDistance = 0.1f;

	public FleeState(Chicken chicken, float speedModifier) : base(chicken.gameObject)
	{
		this._chicken = chicken;
		this._speedModifier = speedModifier;
	}

	public override void OnStart()
	{
		_chicken.SetTarget(_chicken.FleeDestination);
		_chicken.SetSpeed(_speedModifier);
	}

	public override Type Tick()
	{
		var distance = _chicken.Target.position - transform.position;
		_chicken.Input.SetMove(distance.normalized);

		if (distance.magnitude < _stopDistance)
		{
			_chicken.Input.SetMove(Vector2.zero);
			_chicken.SetSpeed(-_speedModifier);
			return typeof(WaitState);
		}

		return null;
	}
}
