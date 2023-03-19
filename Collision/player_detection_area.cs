using Godot;
using System;

public partial class player_detection_area : Area2D
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

	public override void _PhysicsProcess(double delta)
	{
		base._PhysicsProcess(delta);

		if (this._player != null)
		{
			GD.Print(this._player.GlobalPosition);
		}
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
}
