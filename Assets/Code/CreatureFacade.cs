using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;

public class CreatureFacade : MonoBehaviour
{
	public GameObject explosionPrefab;
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

		OnCaptureEvent?.Invoke();
		SpawnExplosion();
	}

	private void SpawnExplosion()
	{
		var instance = GameObject.Instantiate(explosionPrefab, transform.position, Quaternion.identity);
	}
}
