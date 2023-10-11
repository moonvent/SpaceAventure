extends CharacterBody2D


class_name SpaceShip


var SPEED: int
var HEALTH: int


var gun: Gun
var GunScene: PackedScene


func _look_at_position(position_):
    look_at(position_)


func moving(direction):
    velocity = direction * SPEED

    move_and_slide()


func _ready():
    pass


func _physics_process(_delta):
    pass


func fire():
    pass
