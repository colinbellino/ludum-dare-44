using System;
using UnityEngine;

public class AIInput : MonoBehaviour, IInput
{
	public Vector2 Move => _move;

	private Vector2 _move;

	public void SetMove(Vector2 move)
	{
		_move = move;
	}
}
