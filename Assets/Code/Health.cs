using System;
using UnityEditor;
using UnityEngine;

public class Health : MonoBehaviour
{
	[SerializeField] private int _defaultCurrent = 100;
	[SerializeField] private int _defaultMax = 100;

	public Action HealthChangeAction = delegate { };

	public int current { get; private set; }
	public int max { get; private set; }

	private void OnEnable()
	{
		max = _defaultMax;
		ClampCurrentHealth(_defaultCurrent);
	}

	private void ClampCurrentHealth(int value)
	{
		current = Math.Max(0, Math.Min(max, value));
		HealthChangeAction();
	}

	public void AddHealth(int value)
	{
		ClampCurrentHealth(current + value);
	}
}

[CustomEditor(typeof(Health))]
public class HealthEditor : Editor
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

		var health = (Health) target;

		if (GUILayout.Button("Add 10 Health"))
		{
			Debug.Log("+10");
			health.AddHealth(10);
		}

		if (GUILayout.Button("Remove 10 Health"))
		{
			Debug.Log("-10");
			health.AddHealth(-10);
		}
	}
}
