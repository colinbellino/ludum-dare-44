using System;
using UnityEditor;
using UnityEngine;

public class HealthTicker : MonoBehaviour
{
	[SerializeField] private float tick = 3f;
	[SerializeField] private int damagePerTick = 1;

	private Health playerHealth;
	private float timestamp;

	private void OnEnable()
	{
		var player = GameObject.FindGameObjectWithTag("Player");
		playerHealth = player.GetComponent<Health>();
	}

	private void Update()
	{
		if (Time.time > timestamp)
		{
			playerHealth.AddHealth(-damagePerTick);

			timestamp = Time.time + tick;
		}
	}
}
