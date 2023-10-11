extends Node2D


@onready var first_level_handler: FirstLevelHandler = %FirstLevelHandler
@onready var Stages := FirstLevelHandler.Stages

# dict with key - stage, value - handler of this stage
var stage_handler: Dictionary


func init():
    $SpawnEnemyTimer.timeout.connect(create_new_enemy)

    stage_handler = {
        Stages.FIRST: create_first_stage_enemy,
        Stages.SECOND: create_second_stage_enemy,
        Stages.THIRD: create_third_stage_enemy,
        Stages.FOURTH: create_fourth_stage_enemy,
    }


func _ready():
    init()


func create_new_enemy():
    stage_handler[first_level_handler.stage].call()


func create_first_stage_enemy():
    print("First enemy")


func create_second_stage_enemy():
    print("Second enemy")


func create_third_stage_enemy():
    print("Third enemy")


func create_fourth_stage_enemy():
    print("Fourth enemy")


func _physics_process(_delta):
    pass

