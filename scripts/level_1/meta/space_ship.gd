extends CharacterBody2D


class_name SpaceShip


var health: int

var speed: int
var direction: Vector2                    # direction of ship, or bullet
var look_at_position_coords: Vector2

var gun: Gun
var GunScene: PackedScene


func _look_at_position(position_):
	look_at(position_)


func moving(move_direction):
	velocity = move_direction * speed

	move_and_slide()


func _ready():
	pass


func decrease_health(decrease_amount: int):
	health -= decrease_amount

	if health <= 0:
		death()
		

func death():
	queue_free()
