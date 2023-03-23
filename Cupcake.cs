using Godot;
using System;

public partial class Cupcake : CharacterBody2D
{
	[Export]
	private float Speed = 50f;

	private PlayerDetectionArea _playerDetectionArea = null;

	public override void _Ready()
	{
		this._playerDetectionArea = GetNode<PlayerDetectionArea>("PlayerDetectionArea");
	}

	public override void _PhysicsProcess(double delta)
	{
		base._PhysicsProcess(delta);

		Vector2 velocity = Velocity;

		Vector2 playerPosition = this._playerDetectionArea.GetPlayerPosition();
		if (playerPosition != Vector2.Zero)
		{
			Vector2 direction = (Position - playerPosition).Normalized();
			if (direction != Vector2.Zero)
			{
				velocity.X = direction.X * Speed;
				velocity.Y = direction.Y * Speed;
			}
			else
			{
				velocity = Vector2.Zero;
			}
		}
		else
		{
			velocity = Vector2.Zero;
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
