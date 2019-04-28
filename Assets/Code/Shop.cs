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
	private bool lastDisplayItemStatus;

	private void OnEnable()
	{
		UpgradeItems = new List<UpgradeItemsData>();
		player = GameObject.FindWithTag("Player");
		lastDisplayItemStatus = false;
		int count = 0;
		foreach (Upgrade upgrade in UpgradeList)
		{
			UpgradeItems.Add(GenerateUpgradeItem(upgrade));
			count++;
		}
	}

	private void Update()
	{
		// Could be move to a specific script OnUpgradeChosen
		UpgradeItemsData upgradeItem;
		if (UpgradeItems.Contains(UpgradeItems[0]) && UpgradeItems[0].item.activeSelf)
		{
			if (Input.GetButton("Select-1"))
			{
				upgradeItem = UpgradeItems[0];
				var data = new UpgradeChosenData() {cost = upgradeItem.upgrade.cost, id = upgradeItem.upgrade.id};

				UpgradeChosenAction(data);
				DisplayItems(false);
				UpgradeItems.RemoveAt(0);
			}

			if (Input.GetButton("Select-2") && UpgradeItems.Contains(UpgradeItems[1]))
			{
				upgradeItem = UpgradeItems[1];
				var data = new UpgradeChosenData() {cost = upgradeItem.upgrade.cost, id = upgradeItem.upgrade.id};

				UpgradeChosenAction(data);
				DisplayItems(false);
				UpgradeItems.RemoveAt(1);
			}

			if (Input.GetButton("Select-3") && UpgradeItems.Contains(UpgradeItems[2]))
			{
				upgradeItem = UpgradeItems[2];
				var data = new UpgradeChosenData() {cost = upgradeItem.upgrade.cost, id = upgradeItem.upgrade.id};

				UpgradeChosenAction(data);
				DisplayItems(false);
				UpgradeItems.RemoveAt(2);
			}

			if (Input.GetButton("Select-4") && UpgradeItems.Contains(UpgradeItems[3]))
			{
				upgradeItem = UpgradeItems[3];
				var data = new UpgradeChosenData() {cost = upgradeItem.upgrade.cost, id = upgradeItem.upgrade.id};

				UpgradeChosenAction(data);
				DisplayItems(false);
				UpgradeItems.RemoveAt(3);
			}

			if (Input.GetButton("Select-5") && UpgradeItems.Contains(UpgradeItems[4]))
			{
				upgradeItem = UpgradeItems[4];
				var data = new UpgradeChosenData() {cost = upgradeItem.upgrade.cost, id = upgradeItem.upgrade.id};

				UpgradeChosenAction(data);
				DisplayItems(false);
				UpgradeItems.RemoveAt(4);
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.transform != player.transform && lastDisplayItemStatus != true)
		{
			return;
		}

		DisplayItems(true);
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.transform != player.transform && lastDisplayItemStatus != false)
		{
			return;
		}

		DisplayItems(false);
	}

	private UpgradeItemsData GenerateUpgradeItem(Upgrade upgrade)
	{
		var UpgradeItem = Instantiate(UpgradePrefab);

		UpgradeItem.name = "Upgrade : " + upgrade.name;
		UpgradeItem.GetComponent<UpgradeItem>().SetLabel(upgrade.name);
		UpgradeItem.GetComponent<UpgradeItem>().SetCost("" + upgrade.cost);
		UpgradeItem.SetActive(false);

		return new UpgradeItemsData() {item = UpgradeItem, upgrade = upgrade};
	}

	private void DisplayItems(bool display)
	{
		var count = 0;
		foreach (var upgradeItem in UpgradeItems)
		{
			// Reset all position and Input text when display items
			if (display)
			{
				Debug.Log("Show");
				var currentSpawnPoints = new Vector3(count, transform.position.y + 1, 0);
				upgradeItem.item.transform.position = currentSpawnPoints;
				upgradeItem.item.GetComponent<UpgradeItem>().SetInputText("" + (count + 1));
			}

			upgradeItem.item.SetActive(display);
			count++;
		}

		lastDisplayItemStatus = display;
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
