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
			var randomIndex = Random.Range(0, clips.Length - 1);
			source.clip = clips[randomIndex];
			source.Play();

			timestamp = Time.time + playInterval;
		}
	}
}
