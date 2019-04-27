using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeOnTriggerEnter : MonoBehaviour
{
	private GameObject player;
	private ChickenAI chickenAi;

	private void OnEnable()
	{
		CollisionEventBroadcaster.TriggerEnterAction += FleeWhenPlayerEnter;
		player = GameObject.FindWithTag("Player");
		chickenAi = GetComponent<ChickenAI>();
	}

	private void OnDisable()
	{
		CollisionEventBroadcaster.TriggerEnterAction -= FleeWhenPlayerEnter;
	}

	private void FleeWhenPlayerEnter(TriggerEnterData data)
	{
		// if the source was with me.
		if (data.source.transform != transform) { return; }

		if (data.other.transform == player.transform)
		{
			chickenAi.FleeFromTarget(player.transform.position);
		}
	}
}
