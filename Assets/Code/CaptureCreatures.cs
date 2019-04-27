using System;
using UnityEngine;

public class CaptureCreatures : MonoBehaviour
{
	public Action<CaptureData> CaptureAction = delegate { };

	private void OnGUI()
	{
		Event e = Event.current;

		if (e.isKey && e.keyCode == KeyCode.Return)
		{
			Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1f);

			for (int i = 0; i < colliders.Length; i++)
			{
				if (colliders[i].transform == transform)
				{
					continue;
				}

				// Destroy captured creature
				Debug.Log("You successfully capture something, is it a Chicken ?!");
				GameObject.Destroy(colliders[i].transform.gameObject);

				// Send capture event
				var captureData = new CaptureData { captured = colliders[i].transform };
				CaptureAction(captureData);
			}
		}
	}
}

public class CaptureData
{
	public Transform captured;
}
