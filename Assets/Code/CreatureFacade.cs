using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;

public class CreatureFacade : MonoBehaviour
{
	public Creature CreatureData;

	public UnityEvent OnCaptureEvent;

	private void OnEnable()
	{
		OnContact.CaptureAction += OnCapture;
	}

	private void OnDisable()
	{
		OnContact.CaptureAction -= OnCapture;
	}

	private void OnValidate()
	{
		Assert.IsNotNull(CreatureData, "Missing creature data.");
	}

	private void OnCapture(CaptureData data)
	{
		if (data.captured != transform) { return; }

		if (OnCaptureEvent != null)
		{
			OnCaptureEvent.Invoke();
		}
	}
}
