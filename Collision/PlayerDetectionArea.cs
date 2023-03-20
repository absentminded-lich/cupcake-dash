using Godot;
using System;

public partial class PlayerDetectionArea : Area2D
{
	[Export]
	private int Radius = 50;

	private Node2D _player = null;
	private CollisionShape2D _collisionShape2d = null;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this._collisionShape2d = GetNode<CollisionShape2D>("CollisionShape2D");
		if (this._collisionShape2d != null )
		{
			((CircleShape2D)this._collisionShape2d.Shape).Radius = this.Radius;
		}
	}

	public bool IsPlayerColliding()
	{
		return this._player != null;
	}

	public Vector2 GetPlayerPosition()
	{
		if (this.IsPlayerColliding())
		{
			return this._player.Position;
		}

		return Vector2.Zero;
	}

	private void OnPlayerDetectionAreaBodyEntered(Node2D body)
	{
		foreach(String group in body.GetGroups())
		{
			if (group.Equals("player"))
			{
				this._player = body;
			}
		}
	}

	private void OnPlayerDetectionAreaBodyExited(Node2D body)
	{
		if (this._player != null && body == this._player)
		{
			this._player = null;
		}
	}
}
