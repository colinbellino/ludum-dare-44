using UnityEngine;

public class Damageable : MonoBehaviour
{
	[SerializeField] private float knockback;
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
		if (data.target.transform != transform)
		{
			return;
		}


		playerHealth.AddHealth(-data.damage);

		Knockback(data.target.transform, data.source.transform, knockback, -1);
		// TODO: Play hurt sound.
		// TODO: Visual
	}

	private void Knockback(Transform source, Transform target, float knockback, int direction)
	{
		var rb = source.GetComponent<Rigidbody2D>();
		var difference = target.position - transform.position;
		difference = direction * difference.normalized * knockback;

		rb.AddForce(difference, ForceMode2D.Impulse);
	}
}
