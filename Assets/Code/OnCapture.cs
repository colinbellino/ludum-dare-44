using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCapture : MonoBehaviour
{
	private CaptureCreatures captureCreatures;
	private Health playerHealth;

	private void OnEnable()
	{
		captureCreatures = GetComponent<CaptureCreatures>();
		playerHealth = GetComponent<Health>();
		captureCreatures.CaptureAction += OnCreatureCaptured;
	}

	private void OnDisable()
	{
		captureCreatures.CaptureAction -= OnCreatureCaptured;
	}

	private void OnCreatureCaptured(CaptureData data)
	{
		switch (data.captured.name)
		{
				case "Chicken":
					playerHealth.AddHealth(10);
					break;
				default:
					Debug.Log("Hey what did you capture ?");
					break;
		}
	}
}
