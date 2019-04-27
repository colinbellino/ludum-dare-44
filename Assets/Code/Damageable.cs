using UnityEngine;

public class Damageable : MonoBehaviour
{
	private void OnEnable()
	{
		Collisions.TriggerEnterAction += OnTriggerAction;
	}

	private void OnDisable()
	{
		Collisions.TriggerEnterAction -= OnTriggerAction;
	}

	private void OnTriggerAction(TriggerEnterData data)
	{
		// if the collision was with me
		if (data.other.transform != transform) { return; }

		Debug.Log("trigger -> " + data.source.name + " / " + data.other.name);
	}
}
