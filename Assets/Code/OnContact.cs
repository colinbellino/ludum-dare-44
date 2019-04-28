using System;
using System.Linq;
using UnityEngine;

public class OnContact : MonoBehaviour
{
	public Action<CaptureData> CaptureAction = delegate { };

	private void Update()
	{
		CaptureCreature(Input.GetButton("Capture"));
	}

	private void CaptureCreature(bool isCapture)
	{
		if (!isCapture)
		{
			return;
		}

		var colliders = Physics2D.OverlapCircleAll(transform.position, 1f);

		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].transform == transform || !colliders[i].CompareTag("Creature"))
			{
				continue;
			}

			// Destroy captured creature
			Debug.Log("You successfully capture something, is it a Chicken ?!");
			GameObject.Destroy(colliders[i].transform.gameObject);

			// Send capture event
			var captureData = new CaptureData {captured = colliders[i].transform};
			CaptureAction(captureData);
		}
	}
}

public class QuestData
{
}

public class CaptureData
{
	public Transform captured;
}
