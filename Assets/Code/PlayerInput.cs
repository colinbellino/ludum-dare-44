using UnityEngine;

public class PlayerInput : MonoBehaviour, IInput
{
	public Vector2 move { get; private set; }

	private void Update()
	{
		var moveX = Input.GetAxis("Horizontal");
		var moveY = Input.GetAxis("Vertical");

		move = new Vector2(moveX, moveY);
	}
}
