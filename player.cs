using Godot;
using System;
using System.Threading.Tasks;

public partial class player : Godot.CharacterBody2D
{
	private const int GridSnap = 64;
	private const float Speed = 0.75f;

	private Godot.Area2D _area2d = null;

	private bool _isMoving = false;

	public override void _Ready()
	{
		this._area2d = GetNode<Area2D>("Area2D");
	}

	public override void _Input(InputEvent @event)
	{
		if (Input.IsActionPressed("ui_down"))
		{
			this.Move(Vector2.Down);
		}
		if (Input.IsActionPressed("ui_left"))
		{
			this.Move(Vector2.Left);
		}
		if (Input.IsActionPressed("ui_right"))
		{
			this.Move(Vector2.Right);
		}
		if (Input.IsActionPressed("ui_up"))
		{
			this.Move(Vector2.Up);
		}
	}

	public override void _Process(double delta)
	{
	}

	public void Move(Vector2 pos)
	{
		this.MoveTween(pos);
	}

	public async void MoveTween(Vector2 dir)
	{
		if (this._isMoving) return;

		this._isMoving = true;
		this._area2d.Monitoring = true;

		Vector2 newPos = Vector2.Zero;
		newPos.X = GlobalPosition.X + dir.X * GridSnap;
		newPos.Y = GlobalPosition.Y + dir.Y * GridSnap;

		Tween tween = GetTree().CreateTween();
		tween.SetTrans(Tween.TransitionType.Back);
		tween.SetEase(Tween.EaseType.InOut);
		tween.TweenProperty(this, "global_position", newPos, Speed);

		await ToSignal(tween, "finished");

		this._isMoving = false;
		this._area2d.Monitoring = true;
	}

	private void OnArea2DAreaEntered(Area2D area)
	{
		GD.Print("I collide!");
	}
}
