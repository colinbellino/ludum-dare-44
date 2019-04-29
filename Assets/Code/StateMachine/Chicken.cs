using System;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
	[SerializeField] private float _fleeBonusSpeed;
	[SerializeField] private Transform _fleeDestination;
	[SerializeField] private List<Transform> _waypoints = new List<Transform>();

	public StateMachine StateMachine => _stateMachine;
	public List<Transform> Waypoints => _waypoints;
	public Transform FleeDestination => _fleeDestination;

	public AIInput Input => _input;
	public Transform Target => _target;
	public void SetTarget(Transform target) => _target = target;

	private StateMachine _stateMachine;
	private AIInput _input;
	private Transform _target;
	private Movement _movement;

	private void Awake()
	{
		_input = GetComponent<AIInput>();
		_stateMachine = GetComponent<StateMachine>();
		_movement = GetComponent<Movement>();

		InitializeStateMachine();
	}

	private void OnValidate()
	{
		if (_waypoints.Count < 1)
		{
			Debug.LogWarning("Missing waypoints.");
		}
	}

	private void InitializeStateMachine()
	{
		var states = new Dictionary<Type, BaseState>()
			{ //
				{ typeof(PatrolState), new PatrolState(this) }, //
				{ typeof(FleeState), new FleeState(this, _fleeBonusSpeed) }, //
				{ typeof(WaitState), new WaitState(this) } //
			};

		_stateMachine.SetStates(states);
	}

	public void SetSpeed(float speedModifier)
	{
		_movement.SetSpeed(_movement.Speed + speedModifier);
	}
}
