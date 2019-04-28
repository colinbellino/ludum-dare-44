using UnityEngine;

public class Damageable : MonoBehaviour
{
	[SerializeField] private float knockbak;
	private Health playerHealth;

	private void OnEnable()
	{
		DamageOnTriggerEnter.DamageAction += ReceiveDamage;
		playerHealth = GetComponent<Health>();
	}

	private void OnDisable()
	{
		DamageOnTriggerEnter.DamageAction -= ReceiveDamage;
	}

	private void ReceiveDamage(DamageData data)
	{
		// if the collision was with me
		if (data.target.transform != transform) { return; }

		var rb = data.target.GetComponent<Rigidbody2D>();
		var input = GetComponent<IInput>();

		playerHealth.AddHealth(-data.damage);

		var difference = data.source.position - transform.position;
		difference = -difference.normalized * knockbak;

		Debug.Log("Outch ! " + difference);

		rb.AddForce(difference, ForceMode2D.Impulse);
		// TODO: Play hurt sound.
		// TODO: Knock back
		// TODO: Visual
	}
}
