using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;

public class UpgradeItem : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI label;
	[SerializeField] private TextMeshProUGUI cost;
	[SerializeField] private TextMeshProUGUI input;

	public void SetLabel(string text)
	{
		label.text = text;
	}

	public void SetCost(string text)
	{
		cost.text = text + " HP";
	}

	public void SetInputText(string text)
	{
		input.text = text;
	}
}
