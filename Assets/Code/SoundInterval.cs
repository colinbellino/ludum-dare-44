using System;
using UnityEngine;

public class SoundInterval : MonoBehaviour
{
	[SerializeField] private AudioSource source;
	[SerializeField] private AudioClip[] clips;
	[SerializeField] private float playInterval = 1f;

	private float timestamp;

	private void Update()
	{
		if (Time.time > timestamp)
		{
			source.clip = clips[0];
			source.Play();

			timestamp = Time.time + playInterval;
		}
	}
}
