using Godot;

public partial class player : Godot.CharacterBody2D
{
	private const float Speed = 100f;

	private Godot.Area2D _area2d = null;

	public override void _Ready()
	{
		this._area2d = GetNode<Area2D>("Area2D");
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
			velocity.Y = direction.Y * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}

	private void OnArea2DAreaEntered(Area2D area)
	{
		GD.Print("I collide!");
	}
}
