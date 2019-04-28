using UnityEditor.U2D;
using UnityEngine;

public class Damageable : MonoBehaviour
{
	private Health playerHealth;

	private void OnEnable()
	{
		DamageOnTriggerEnter.DamageAction += ReceiveDamage;
		Shop.UpgradeChosenAction += ReceiveUpgrade;
		playerHealth = GetComponent<Health>();
	}

	private void OnDisable()
	{
		DamageOnTriggerEnter.DamageAction -= ReceiveDamage;
		Shop.UpgradeChosenAction -= ReceiveUpgrade;
	}

	private void ReceiveDamage(DamageData data)
	{
		// if the collision was with me
		if (data.target.transform != transform) { return; }

		Debug.Log("BIM -> " + (-data.damage));

		playerHealth.AddHealth(-data.damage);

		// TODO: Decrease HP ?
		// TODO: Play hurt sound.
	}

	private void ReceiveUpgrade(UpgradeChosenData data)
	{
		ReceiveDamage(new DamageData() {target = transform, damage = data.cost});
		Debug.Log("Upgrade received with ID : " + data.id);
	}
}
