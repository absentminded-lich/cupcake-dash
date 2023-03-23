using Godot;
using System;

public partial class Cupcake : CharacterBody2D
{
	[Export]
	private int Speed = 50;
	
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
			Vector2 moveToward = Position + (Position - playerPosition).Normalized();
			Position = Position.Lerp(moveToward, (float)(delta * Speed));
		}
	}
}
