using System;
using UnityEngine;

public class DamageOnTriggerEnter : MonoBehaviour
{
	private Creature CreatureData;
	public static Action<DamageData> DamageAction = delegate { };

	private void OnEnable()
	{
		CreatureData = GetComponent<CreatureFacade>().CreatureData;
		CollisionEventBroadcaster.TriggerEnterAction += BroadcastDamageAction;
	}

	private void OnDisable()
	{
		CollisionEventBroadcaster.TriggerEnterAction -= BroadcastDamageAction;
	}

	private void BroadcastDamageAction(TriggerEnterData data)
	{
		// if the source was with me.
		if (data.source.transform != transform) { return; }

		var actionData = new DamageData { target = data.other.transform, damage = CreatureData.damage, source = data.source };
		DamageAction(actionData);
	}
}

public class DamageData
{
	public Transform target;
	public Transform source;
	public int damage;
}
