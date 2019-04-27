using UnityEngine;

public class HealthUI : MonoBehaviour
{
	[SerializeField] private TMPro.TextMeshProUGUI currentHealthText;
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
		currentHealthText.text = $"{playerHealth.current} / {playerHealth.max}";
	}
}
