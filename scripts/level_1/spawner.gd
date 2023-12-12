extends Node2D


class_name Spawner

var window_size := DisplayServer.window_get_size()
var window_size_half_for_spawn_enemies: Vector2

@onready var first_level_handler: FirstLevelHandler = %FirstLevelHandler
@onready var Stages := FirstLevelHandler.Stages


enum SpawnSide {
	UP,
	RIGHT,
	DOWN,
	LEFT
}

var available_sides: Array

# dict with key - stage, value - handler of this stage
var stage_handler: Dictionary

var spawn_position: Vector2
var spawn_side: int

var enemy: Enemy

var player: Player
var player_current_half_position: Vector2
var current_border_size: Vector2
var range_between_border_and_invisible_spawn_point: int


func init():
	$SpawnEnemyTimer.timeout.connect(create_new_enemy)

	stage_handler = {
		Stages.FIRST: create_first_stage_enemy,
		Stages.SECOND: create_second_stage_enemy,
		Stages.THIRD: create_third_stage_enemy,
		Stages.FOURTH: create_fourth_stage_enemy,
	}

	available_sides = Array()

	for side in SpawnSide:
		available_sides.append(SpawnSide[side])

	player = get_node("../Player")
	#var camera_zoom_multiplier = get_node("../Player/Camera2D").zoom[0]
	window_size_half_for_spawn_enemies = window_size / 2
	range_between_border_and_invisible_spawn_point = Config.RANGE_BETWEEN_CAMERA_BORDER_AND_SPAWN_POINT


func _ready():
	randomize()
	init()


func create_new_enemy():
	get_spawn_coords()
	stage_handler[first_level_handler.current_stage].call()


func create_first_stage_enemy():
	enemy = GlobalResourceLoader.FirstStageEnemy.instantiate()
	enemy.position = spawn_position
	add_child(enemy)


func create_second_stage_enemy():
	enemy = GlobalResourceLoader.SecondStageEnemy.instantiate()
	enemy.position = spawn_position
	add_child(enemy)


func create_third_stage_enemy():
	print("Third enemy")


func create_fourth_stage_enemy():
	print("Fourth enemy")


func get_spawn_coords():
	spawn_position = Vector2()

	spawn_side = available_sides[randi() % available_sides.size()]

	current_border_size = window_size_half_for_spawn_enemies
	player_current_half_position = player.position

	match spawn_side:
		SpawnSide.UP:
			spawn_position.x = player_current_half_position.x - window_size_half_for_spawn_enemies.x + int(randf() * current_border_size.x)
			spawn_position.y = player_current_half_position.y - window_size_half_for_spawn_enemies.y - range_between_border_and_invisible_spawn_point
		SpawnSide.DOWN:  
			spawn_position.x = player_current_half_position.x - window_size_half_for_spawn_enemies.x + int(randf() * current_border_size.x)
			spawn_position.y = player_current_half_position.y + window_size_half_for_spawn_enemies.y  + range_between_border_and_invisible_spawn_point
		SpawnSide.LEFT:  
			spawn_position.x = player_current_half_position.x - window_size_half_for_spawn_enemies.x - range_between_border_and_invisible_spawn_point
			spawn_position.y = player_current_half_position.y - window_size_half_for_spawn_enemies.y + int(randf() * current_border_size.y)
		SpawnSide.RIGHT:  
			spawn_position.x = player_current_half_position.x + window_size_half_for_spawn_enemies.x + range_between_border_and_invisible_spawn_point
			spawn_position.y = player_current_half_position.y - window_size_half_for_spawn_enemies.y + int(randf() * current_border_size.y)

