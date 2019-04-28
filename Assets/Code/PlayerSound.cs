using UnityEngine;

public class PlayerSound : MonoBehaviour
{
	[SerializeField] private AudioClip CaptureSound;
	private AudioPlayer audioPlayer;

	private void OnEnable()
	{
		audioPlayer = GetComponent<AudioPlayer>();
	}

	public void PlayCaptureSound()
	{
		audioPlayer.PlayOneShot(CaptureSound);
	}
}
