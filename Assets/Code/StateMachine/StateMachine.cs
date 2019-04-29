using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
	private Dictionary<Type, BaseState> _availableStates = new Dictionary<Type, BaseState>();

	public BaseState CurrentState { get; private set; }
	public event Action<BaseState> OnStateChanged;

	public void SetStates(Dictionary<Type, BaseState> states)
	{
		_availableStates = states;
	}

	private void Update()
	{
		if (_availableStates.Count == 0)
		{
			Debug.LogError("Empty states list");
			return;
		}

		if (CurrentState == null)
		{
			SwitchToNewState(_availableStates.Values.First().GetType());
		}

		var nextState = (Type) CurrentState.Tick();

		if (nextState != null && nextState != CurrentState.GetType())
		{
			SwitchToNewState(nextState);
		}
	}

	private void SwitchToNewState(Type nextState)
	{
		if (CurrentState != null)
		{
			CurrentState.OnEnd();
		}

		CurrentState = _availableStates[nextState];
		CurrentState.OnStart();
		OnStateChanged?.Invoke(CurrentState);
	}
}
