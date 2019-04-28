using System;
using System.Linq;
using UnityEngine;

public class OnContact : MonoBehaviour
{
	public static Action<CaptureData> CaptureAction = delegate { };
	[SerializeField] private GameObject PlayerProjectile;
	private GameObject ProjectileInstance;
	private IInput input;

	private void OnEnable()
	{
		input = GetComponent<IInput>();

		if (PlayerProjectile)
		{
			ProjectileInstance = Instantiate(PlayerProjectile);
			ProjectileInstance.SetActive(false);
		}
	}

	private void Update()
	{
		if (Input.GetButton("Capture"))
		{
			var positionToCapture = CalculateProjectilePosition();

			CaptureCreature(positionToCapture);
			ProjectileInstance.transform.position = positionToCapture;
			ProjectileInstance.SetActive(true);
		}
		else
		{
			ProjectileInstance.SetActive(false);
		}
	}

	private void CaptureCreature(Vector3 positionToCapture)
	{
		var colliders = Physics2D.OverlapCircleAll(positionToCapture, 1f);

		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].transform == transform || !colliders[i].CompareTag("Creature"))
			{
				continue;
			}

			// Send capture event
			var captureData = new CaptureData {captor = transform, captured = colliders[i].transform};
			CaptureAction(captureData);
		}
	}

	private Vector3 CalculateProjectilePosition()
	{
		var positionToCapture = (Vector3) (input.move.normalized * 2) + transform.position;

		return positionToCapture;
	}
}

public class QuestData
{
}

public class CaptureData
{
	public Transform captor;
	public Transform captured;
}
