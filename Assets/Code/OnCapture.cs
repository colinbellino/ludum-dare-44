using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCapture : MonoBehaviour
{
	private OnContact CaptureCreatures;
	private Health PlayerHealth;
	private PlayerBag PlayerBag;

	private void OnEnable()
	{
		CaptureCreatures = GetComponent<OnContact>();
		PlayerHealth = GetComponent<Health>();
		PlayerBag = GetComponent<PlayerBag>();
		CaptureCreatures.CaptureAction += OnCreatureCaptured;
	}

	private void OnDisable()
	{
		CaptureCreatures.CaptureAction -= OnCreatureCaptured;
	}

	private void OnCreatureCaptured(CaptureData data)
	{
		var capturedCreatureData = data.captured.GetComponent<CreatureFacade>().CreatureData;

		PlayerHealth.AddHealth(capturedCreatureData.health);
		PlayerBag.AddCapturedCreature(capturedCreatureData);

		// TODO: Feedback;
	}
}
