using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

// FIXME: Remove me when we have HP and stuff.
public class GameOverOnNoHealth : MonoBehaviour
{
	private Health playerHealth;
	[SerializeField] private UnityEvent onGameOver;

	private void OnEnable()
	{
		playerHealth = GetComponent<Health>();
		playerHealth.HealthChangeAction += TriggerGameOver;
	}

	private void OnDisable()
	{
		playerHealth.HealthChangeAction -= TriggerGameOver;
	}

	private void TriggerGameOver()
	{
		if (playerHealth.current != 0)
		{
			return;
		}

		Debug.Log("T'es mort POULET !");
		SceneManager.LoadScene("TitleScene", LoadSceneMode.Single);

		if (onGameOver != null) {
			onGameOver.Invoke();
		}
	}
}
