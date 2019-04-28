using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class CreatureFacade : MonoBehaviour
{
	public Creature CreatureData;

	private void OnValidate()
	{
		Assert.IsNotNull(CreatureData, "Missing creature data.");
	}
}
