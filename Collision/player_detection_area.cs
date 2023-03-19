using Godot;
using System;

public partial class player_detection_area : Area2D
{
	[Export]
	private int Radius = 50;

	private Godot.CollisionShape2D _collisionShape2d = null;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
		this._collisionShape2d = GetNode<CollisionShape2D>("CollisionShape2D");
		if (this._collisionShape2d != null )
		{
			((CircleShape2D)this._collisionShape2d.Shape).Radius = this.Radius;
        }
    }
}
