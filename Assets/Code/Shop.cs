using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
	[SerializeField] private List<Quest> QuestList;
	private GameObject Player;
	private int currentQuestIndex;

	private void OnEnable()
	{
		currentQuestIndex = 0;
		Player = GameObject.FindWithTag("Player");
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.transform != Player.transform)
		{
			return;
		}

		Debug.Log("Hello Player");
		if (currentQuestIndex < QuestList.Count)
		{
			CompleteQuest();
		}
	}

	private void CompleteQuest()
	{
		var playerBag = Player.GetComponent<PlayerBag>();
		var currentQuest = QuestList[currentQuestIndex];
		var capturedCreatures = playerBag.GetCapturedCreatures();
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
			Debug.Log("Quest done.");
			playerBag.AddUpgrade(currentQuest.upgrade);
			foreach (var creature in currentQuest.creatures)
			{
				Debug.Log("Remove");
				playerBag.RemoveCapturedCreature(creature);
			}
			currentQuestIndex++;
		}
	}
}
