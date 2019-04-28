using System;
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
		var newValue = Math.Max(0, Math.Min(max, value));
		if (current != newValue)
		{
			current = newValue;
			HealthChangeAction();
		}
	}

	public void AddHealth(int value)
	{
		ClampCurrentHealth(current + value);
	}
}

#if UNITY_EDITOR
[UnityEditor.CustomEditor(typeof(Health))]
public class HealthEditor : UnityEditor.Editor
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

		var health = (Health) target;

		if (GUILayout.Button("Add 10 Health"))
		{
			health.AddHealth(10);
		}

		if (GUILayout.Button("Remove 10 Health"))
		{
			health.AddHealth(-10);
		}
	}
}
#endif
