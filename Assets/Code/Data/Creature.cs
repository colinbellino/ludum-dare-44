using UnityEngine;

[CreateAssetMenu(menuName = "LD44/Creatures")]
public class Creature : ScriptableObject
{
	public int id;
	public new string name;
	public int health;
	public int damage;
}
