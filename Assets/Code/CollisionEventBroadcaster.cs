using System;
using UnityEngine;

public class CollisionEventBroadcaster : MonoBehaviour
{
	public static Action<TriggerEnterData> TriggerEnterAction = delegate { };

	private void OnTriggerEnter2D(Collider2D other)
	{
		var data = new TriggerEnterData { source = transform, other = other };
		TriggerEnterAction(data);
	}
}

public class TriggerEnterData
{
	public Transform source;
	public Collider2D other;
}
