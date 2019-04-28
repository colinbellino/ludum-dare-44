using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBag : MonoBehaviour
{
	[SerializeField] private Creature CreatureObject;
	private List<Creature> CapturedCreatures;
	private List<Upgrade> Upgrades;

	private void OnEnable()
	{
		CapturedCreatures = new List<Creature> {CreatureObject, CreatureObject, CreatureObject};
		Upgrades = new List<Upgrade>();
	}

	public List<Creature> GetCapturedCreatures()
	{
		return CapturedCreatures;
	}

	public void RemoveCapturedCreature(Creature creature)
	{
		CapturedCreatures.Remove(creature);
	}

	public void AddUpgrade(Upgrade upgrade)
	{
		Upgrades.Add(upgrade);
	}
}
