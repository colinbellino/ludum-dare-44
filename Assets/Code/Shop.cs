using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
	[SerializeField] private List<Quest> quests = new List<Quest>();
	private GameObject player;
	private int currentQuestIndex;

	private void OnEnable()
	{
		player = GameObject.FindWithTag("Player");
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.transform != player.transform)
		{
			return;
		}

		if (currentQuestIndex < quests.Count)
		{
			CompleteQuest();
		}
	}

	private void CompleteQuest()
	{
		var playerBag = player.GetComponent<PlayerBag>();
		var currentQuest = quests[currentQuestIndex];
		var capturedCreatures = new List<Creature>(playerBag.GetCapturedCreatures());
		var countQuestDone = 0;

		foreach (var creature in currentQuest.creatures)
		{
			if (capturedCreatures.Contains(creature))
			{
				capturedCreatures.Remove(creature);
				countQuestDone++;
			}
		}

		if (countQuestDone == currentQuest.creatures.Count)
		{
			playerBag.AddUpgrade(currentQuest.upgrade);

			foreach (var creature in currentQuest.creatures)
			{
				playerBag.RemoveCapturedCreature(creature);
			}
			currentQuestIndex++;
		}
	}
}
