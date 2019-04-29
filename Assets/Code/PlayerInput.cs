using UnityEngine;

public class PlayerInput : MonoBehaviour, IInput
{
	public Vector2 Move { get; private set; }

	private void Update()
	{
		var moveX = Input.GetAxis("Horizontal");
		var moveY = Input.GetAxis("Vertical");

		Move = new Vector2(moveX, moveY);
	}
}
