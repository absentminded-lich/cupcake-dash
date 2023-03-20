using Godot;
using System;

public partial class cupcake : StaticBody2D
{
	private player_detection_area _playerDetectionArea = null;

	public override void _Ready()
	{
		this._playerDetectionArea = GetNode<player_detection_area>("PlayerDetectionArea");
	}

	public override void _PhysicsProcess(double delta)
	{
		base._PhysicsProcess(delta);

		Vector2 playerPosition = this._playerDetectionArea.GetPlayerPosition();
		if (playerPosition != Vector2.Zero)
		{
			Vector2 moveToward = Position + (Position - playerPosition);
			Position = Position.Lerp(moveToward, (float)delta);
		}
	}
}
