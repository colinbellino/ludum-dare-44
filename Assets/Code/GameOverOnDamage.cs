using UnityEngine;
using UnityEngine.SceneManagement;

// FIXME: Remove me when we have HP and stuff.
public class GameOverOnDamage : MonoBehaviour
{
	private void OnEnable()
	{
		DamageOnTriggerEnter.DamageAction += TriggerGameOver;
	}

	private void OnDisable()
	{
		DamageOnTriggerEnter.DamageAction -= TriggerGameOver;
	}

	private void TriggerGameOver(DamageData data)
	{
		// if the collision was with me
		if (data.target.transform != transform) { return; }

		var scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(scene.name);
	}
}
