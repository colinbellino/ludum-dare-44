using System;
using UnityEngine;

public class WaitState : BaseState
{
	private Chicken _chicken;
	private float _waitTimestamp;
	private const float _waitDuration = 5f;

	public WaitState(Chicken chicken) : base(chicken.gameObject)
	{
		this._chicken = chicken;
	}

	public override void OnStart()
	{
		_waitTimestamp = Time.time + _waitDuration;
	}

	public override Type Tick()
	{
		if (Time.time > _waitTimestamp)
		{
			return typeof(PatrolState);
		}

		return null;
	}
}
