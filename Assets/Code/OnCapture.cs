using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnCapture : MonoBehaviour
{
	[SerializeField] private UnityEvent CaptureEvent;
	private OnContact CaptureCreatures;
	private Health PlayerHealth;
	private PlayerBag PlayerBag;

	private void OnEnable()
	{
		PlayerHealth = GetComponent<Health>();
		PlayerBag = GetComponent<PlayerBag>();

		OnContact.CaptureAction += OnCreatureCaptured;
	}

	private void OnDisable()
	{
		OnContact.CaptureAction -= OnCreatureCaptured;
	}

	private void OnCreatureCaptured(CaptureData data)
	{
		if (data.captor != transform) { return; }

		// TODO: Feedback;
		var capturedCreatureData = data.captured.GetComponent<CreatureFacade>().CreatureData;

		PlayerHealth.AddHealth(capturedCreatureData.health);
		PlayerBag.AddCapturedCreature(capturedCreatureData);
		CaptureEvent?.Invoke();
	}
}
