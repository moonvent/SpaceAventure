extends Node2D


class_name Spawner

var window_size := DisplayServer.window_get_size()
var window_size_half_for_spawn_enemies: Vector2

@onready var first_level_handler: FirstLevelHandler = %FirstLevelHandler


var available_sides: Array

# dict with key - stage, value - handler of this stage
var stage_handler: Dictionary

var spawn_position: Vector2
var spawn_side: int

var enemy: Enemy

var player: Player
var range_between_border_and_invisible_spawn_point: int
var left_top_point_of_camera_view: Vector2
var right_bottom_point_of_camera_view: Vector2


func init():
	$SpawnEnemyTimer.timeout.connect(create_new_enemy)

	stage_handler = {
		Config.Stages.FIRST: create_first_stage_enemy,
		Config.Stages.SECOND: create_second_stage_enemy,
		Config.Stages.THIRD: create_third_stage_enemy,
		Config.Stages.FOURTH: create_fourth_stage_enemy,
	}

	available_sides = Array()

	for side in Config.SpawnSide:
		available_sides.append(Config.SpawnSide[side])

	player = get_node("../Player")
	get_start_and_end_of_camera()


func get_start_and_end_of_camera():
	var camera = get_viewport().get_camera_2d()
	var primary_size = camera.get_viewport().size
	var zoom = camera.zoom[0]
	var custom_size = primary_size * pow(zoom, -1)
	left_top_point_of_camera_view = Vector2(primary_size) - custom_size
	right_bottom_point_of_camera_view = custom_size
	

func _ready():
	randomize()
	init()


func create_new_enemy():
	get_spawn_coords()
	stage_handler[first_level_handler.current_stage].call()


func spawn_enemy(enemy_scene: PackedScene):
	enemy = enemy_scene.instantiate()
	enemy.position = spawn_position
	add_child(enemy)


func create_first_stage_enemy():
	create_fourth_stage_enemy()
	# spawn_enemy(GlobalResourceLoader.FirstStageEnemy)


func create_second_stage_enemy():
	spawn_enemy(GlobalResourceLoader.SecondStageEnemy)


func create_third_stage_enemy():
	spawn_enemy(GlobalResourceLoader.ThirdStageEnemy)


func create_fourth_stage_enemy():
	spawn_enemy(GlobalResourceLoader.FourthStageEnemy)
	$SpawnEnemyTimer.stop()


func get_spawn_coords():
	spawn_position = Vector2()

	spawn_side = available_sides[randi() % available_sides.size()]

	var random_x_pos = randi_range(left_top_point_of_camera_view.x, right_bottom_point_of_camera_view.x)	
	var random_y_pos = randi_range(left_top_point_of_camera_view.y, right_bottom_point_of_camera_view.y)	

	match spawn_side:
		Config.SpawnSide.UP:
			spawn_position.x = random_x_pos
			spawn_position.y = left_top_point_of_camera_view.y - range_between_border_and_invisible_spawn_point
		Config.SpawnSide.DOWN:  
			spawn_position.x = random_x_pos
			spawn_position.y = right_bottom_point_of_camera_view.y + range_between_border_and_invisible_spawn_point
		Config.SpawnSide.LEFT:  
			spawn_position.x = left_top_point_of_camera_view.x - range_between_border_and_invisible_spawn_point
			spawn_position.y = random_y_pos
		Config.SpawnSide.RIGHT:  
			spawn_position.x = right_bottom_point_of_camera_view.x + range_between_border_and_invisible_spawn_point
			spawn_position.y = random_y_pos
