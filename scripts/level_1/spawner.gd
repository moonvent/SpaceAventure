extends Node2D


var window_size := DisplayServer.window_get_size()

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


func _ready():
    randomize()
    init()


func create_new_enemy():
    get_spawn_coords()
    stage_handler[first_level_handler.current_stage].call()


func create_first_stage_enemy():
    print("First enemy")
    enemy = GlobalResourceLoader.FirstStageEnemy.instantiate()
    enemy.position = spawn_position
    add_child(enemy)


func create_second_stage_enemy():
    print("Second enemy")


func create_third_stage_enemy():
    print("Third enemy")


func create_fourth_stage_enemy():
    print("Fourth enemy")


func get_spawn_coords():
    spawn_position = Vector2()

    spawn_side = available_sides[randi() % available_sides.size()]
    
    match spawn_side:
        SpawnSide.UP:
            spawn_position.x = int(randf() * window_size.x)
            spawn_position.y = -100
        SpawnSide.DOWN:  
            spawn_position.x = int(randf() * window_size.x)
            spawn_position.y = window_size.y + 100
        SpawnSide.LEFT:  
            spawn_position.x = -100
            spawn_position.y = int(randf() * window_size.y)
        SpawnSide.RIGHT:  
            spawn_position.x = window_size.x + 100
            spawn_position.y = int(randf() * window_size.y)
      
