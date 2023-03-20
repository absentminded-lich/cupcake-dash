using Godot;
using System;

public partial class Cupcake : StaticBody2D
{
	private PlayerDetectionArea _playerDetectionArea = null;

	public override void _Ready()
	{
		this._playerDetectionArea = GetNode<PlayerDetectionArea>("PlayerDetectionArea");
	}

	public override void _PhysicsProcess(double delta)
	{
		base._PhysicsProcess(delta);

		Vector2 playerPosition = this._playerDetectionArea.GetPlayerPosition();
		if (playerPosition != Vector2.Zero)
		{
			Vector2 moveToward = Position + (Position - playerPosition);
			Position = Position.Lerp(moveToward, (float)delta * 50);
		}
	}
}
