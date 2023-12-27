extends SpaceShip


class_name Player


# @onready var first_level_ui: FirstLevelUserInterface = %FirstLevelUI as FirstLevelUserInterface


func _init():
	speed = Constant.PlayerPrimaryStats.Speed
	health = Constant.PlayerPrimaryStats.Health


func _physics_process(_delta):

	look_at_position_coords = get_global_mouse_position()
	_look_at_position(look_at_position_coords)

	direction = Input.get_vector(Constant.Action.Left, Constant.Action.Right, Constant.Action.Up, Constant.Action.Down)
	moving(direction)
	
	# if (Input.is_action_pressed(Constant.Action.Fire)):
	# 	gun.fire(look_at_position_coords)
	
	if (Input.is_action_pressed(Constant.Action.Pause)):
		get_tree().paused = true


func decrease_health(decrease_amount: int):
	super(decrease_amount)
	# first_level_ui.change_hp_amount(health)
