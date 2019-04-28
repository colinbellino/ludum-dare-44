using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;

public class UpgradeItem : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI label;

	public void SetLabel(string text)
	{
		label.text = text;
	}
}
