using UnityEngine;

public class SoundInterval : MonoBehaviour
{
	[SerializeField] private AudioClip[] clips;
	[SerializeField] private float playInterval = 1f;

	private AudioPlayer audioPlayer;

	private float timestamp;

	private void OnEnable()
	{
		audioPlayer = GetComponent<AudioPlayer>();
	}

	private void Update()
	{
		if (Time.time > timestamp)
		{
			var randomIndex = Random.Range(0, clips.Length);
			Debug.Log("Chicken sound No " + randomIndex);
			audioPlayer.PlayOneShot(clips[randomIndex]);

			timestamp = Time.time + playInterval;
		}
	}
}
