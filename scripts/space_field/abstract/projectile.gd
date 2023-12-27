extends Area2D


class_name Projectile


var speed: int
var direction: Vector2
var damage: int


func _init(projectile_direction: Vector2, shot_position: Vector2, projectile_speed: int):

	direction = projectile_direction
	position = shot_position
	rotation = projectile_direction.angle()
	speed = projectile_speed

	$SelfDestructionTimer.timeout.connect(self_destruction_action)


func _physics_process(delta):
	position += direction * speed * delta


func self_destruction_action():
	queue_free()

