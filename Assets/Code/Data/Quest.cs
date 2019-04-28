using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LD44/Quest")]
public class Quest: ScriptableObject
{
	public int id;
	public Upgrade upgrade;
	public List<Creature> creatures;
}
