using UnityEngine;
using UnityEngine.SceneManagement;

// FIXME: Remove me when we have HP and stuff.
public class GameOverOnNoHealth : MonoBehaviour
{
	private Health playerHealth;

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
			return ;
		}

		Debug.Log("T'est mort POULET !");
		var scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(scene.name);
	}
}
