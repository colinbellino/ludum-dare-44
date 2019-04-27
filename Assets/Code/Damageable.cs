using UnityEngine;

public class Damageable : MonoBehaviour
{
	private void OnEnable()
	{
		DamageOnTriggerEnter.DamageAction += ReceiveDamage;
	}

	private void OnDisable()
	{
		DamageOnTriggerEnter.DamageAction -= ReceiveDamage;
	}

	private void ReceiveDamage(DamageData data)
	{
		// if the collision was with me
		if (data.target.transform != transform) { return; }

		Debug.Log("BIM -> " + data.damage);

		// TODO: Decrease HP ?
		// TODO: Play hurt sound.
	}
}
