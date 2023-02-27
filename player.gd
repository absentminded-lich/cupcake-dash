extends CharacterBody2D

const GRID_SNAP := 64
const SPEED := 0.75

@onready var area2d = $Area2D

var is_moving := false

func _input(_Input) -> void:
	if Input.is_action_pressed("ui_down"):
		_move(Vector2.DOWN)
	if Input.is_action_pressed("ui_left"):
		_move(Vector2.LEFT)
	if Input.is_action_pressed("ui_right"):
		_move(Vector2.RIGHT)
	if Input.is_action_pressed("ui_up"):
		_move(Vector2.UP)
		
func _move(dir: Vector2) -> void:
	_move_tween(dir)

func _move_tween(dir: Vector2) -> void:
	if (is_moving):
		return
		
	is_moving = true
	area2d.monitoring = false
	var tween : Tween = get_tree().create_tween()
	tween.set_trans(Tween.TRANS_BACK)
	tween.set_ease(Tween.EASE_IN_OUT)
	tween.tween_property(self, "global_position", global_position + dir * GRID_SNAP, SPEED)
	await tween.finished
	
	is_moving = false
	area2d.monitoring = true
	
	
func _on_area_2d_area_entered(area):
	print("I collide!")
