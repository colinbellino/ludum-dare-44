using System;
using UnityEngine;

public class Collisions : MonoBehaviour
{
	public static Action<TriggerEnterData> TriggerEnterAction = delegate { };

	private void OnTriggerEnter2D(Collider2D collider)
	{
		var data = new TriggerEnterData { source = transform, other = collider };
		TriggerEnterAction(data);
	}
}

public class TriggerEnterData
{
	public Transform source;
	public Collider2D other;
}
