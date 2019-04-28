using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerBag : MonoBehaviour
{
	private List<Creature> CapturedCreatures;
	private List<Upgrade> Upgrades;

	private void OnEnable()
	{
		CapturedCreatures = new List<Creature>();
		Upgrades = new List<Upgrade>();
	}

	public List<Creature> GetCapturedCreatures()
	{
		return CapturedCreatures;
	}

	public void AddCapturedCreature(Creature creature)
	{
		CapturedCreatures.Add(creature);
		Debug.Log(creature.name + " captured ! Count: " + CapturedCreatures.Count);
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
