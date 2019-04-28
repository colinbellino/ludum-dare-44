using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
	public static Action<UpgradeChosenData> UpgradeChosenAction = delegate { };
	[SerializeField] private List<Upgrade> UpgradeList;
	[SerializeField] private GameObject UpgradePrefab;
	private List<UpgradeItemsData> UpgradeItems;
	private GameObject player;

	private void OnEnable()
	{
		UpgradeItems = new List<UpgradeItemsData>();
		player = GameObject.FindWithTag("Player");
		int count = 0;
		foreach (Upgrade upgrade in UpgradeList)
		{
			UpgradeItems.Add(GenerateUpgradeItem(upgrade, count));
			count++;
		}
	}

	private void Update()
	{
		var i = 1;
		var indexToRemove = new List<int>();
		foreach (var upgradeItem in UpgradeItems)
		{
			if (Input.GetButton("Select-" + i) && upgradeItem.item.activeSelf)
			{
				var data = new UpgradeChosenData() {cost = upgradeItem.upgrade.cost, id = upgradeItem.upgrade.id};

				UpgradeChosenAction(data);
				upgradeItem.item.SetActive(false);
				indexToRemove.Add(i - 1);
				i++;
			}
		}

		foreach (var index in indexToRemove)
		{
			UpgradeItems.RemoveAt(index);
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.transform != player.transform)
		{
			return;
		}

		DisplayItems(true);
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.transform != player.transform)
		{
			return;
		}

		DisplayItems(false);
	}

	private UpgradeItemsData GenerateUpgradeItem(Upgrade upgrade, int offset)
	{
		var currentSpawnPoints = new Vector3(offset, transform.position.y + 1, 0);

		var UpgradeItem = Instantiate(UpgradePrefab);
		UpgradeItem.name = "Upgrade : " + upgrade.name;
		UpgradeItem.transform.position = currentSpawnPoints;
		UpgradeItem.GetComponent<UpgradeItem>().SetLabel(upgrade.name);
		UpgradeItem.SetActive(false);

		return new UpgradeItemsData() {item = UpgradeItem, upgrade = upgrade};
	}

	private void DisplayItems(bool display)
	{
		foreach (var upgradeItem in UpgradeItems)
		{
			upgradeItem.item.SetActive(display);
		}
	}
}

public class UpgradeItemsData
{
	public GameObject item;
	public Upgrade upgrade;
}

public class UpgradeChosenData
{
	public int cost;
	public int id;
}
