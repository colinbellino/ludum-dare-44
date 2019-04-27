using System;
using UnityEngine;

public class Health : MonoBehaviour
{
	[SerializeField] private int _current = 100;
	[SerializeField] private int _max = 100;

	public Action HealthChangeAction = delegate { };

	public int current { get; private set; }
	public int max { get; private set; }

	private void OnEnable()
	{
		max = _max;
		ClampCurrentHealth(_current);
	}

	private void ClampCurrentHealth(int value)
	{
		current = Math.Max(max, Math.Min(0, value));
		HealthChangeAction();
	}

	public void AddHealth(int value)
	{
		ClampCurrentHealth(current + value);
	}
}
