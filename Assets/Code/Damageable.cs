using UnityEditor.U2D;
using UnityEngine;

public class Damageable : MonoBehaviour
{
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

		Debug.Log("BIM -> " + (-data.damage));

		playerHealth.AddHealth(-data.damage);

		Debug.Log(playerHealth.current);
		// TODO: Decrease HP ?
		// TODO: Play hurt sound.
	}
}
