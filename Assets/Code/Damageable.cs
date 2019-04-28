using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
	[SerializeField] private float knockback;
	private Health playerHealth;
	private Rigidbody2D rb;
	public UnityEvent OnHit;

	private void OnEnable()
	{
		DamageOnTriggerEnter.DamageAction += ReceiveDamage;
		playerHealth = GetComponent<Health>();
		rb = GetComponent<Rigidbody2D>();
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

		// TODO: Play hurt sound.
		// TODO: Visual
		Knockback(data.target.transform, data.source.transform, knockback, -1);
		OnHit.Invoke();
	}

	private void Knockback(Transform source, Transform target, float knockback, int direction)
	{
		var difference = (target.position - transform.position);
		// Debug.Log("difference " + difference);

		rb.AddForce(difference, ForceMode2D.Impulse);
	}
}
