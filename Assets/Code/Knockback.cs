using UnityEngine;

public class Knockback: MonoBehaviour
{
	[SerializeField] private float thrust;
	private Rigidbody2D rb;

	private void OnEnabled()
	{
		rb = GetComponent<Rigidbody2D>();
	}
}
