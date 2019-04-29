using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
	// [SerializeField] private TMPro.TextMeshProUGUI currentHealthText;
	[SerializeField] private Image healthBar;
	private Health playerHealth;

	private void OnEnable()
	{
		var player = GameObject.FindGameObjectWithTag("Player");
		playerHealth = player.GetComponent<Health>();

		playerHealth.HealthChangeAction += RefreshUI;
	}

	private void OnDisable()
	{
		playerHealth.HealthChangeAction -= RefreshUI;
	}

	private void RefreshUI()
	{
		// currentHealthText.text = $"{playerHealth.current} / {playerHealth.max}";
		float barP = (float) playerHealth.current / playerHealth.max;
		healthBar.transform.localScale = new Vector2(1f, barP);
	}
}
