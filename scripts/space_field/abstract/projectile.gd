extends Area2D


class_name Projectile


var speed: int
var direction: Vector2
var damage: int


func init(projectile_direction: Vector2, shot_position: Vector2):

	direction = projectile_direction
	position = shot_position
	rotation = projectile_direction.angle()

	# print(get_node("Sprite2D"))
	# $SelfDestructionTimer.timeout.connect(self_destruction_action)


func _ready():
	pass


func _physics_process(delta):
	position += direction * speed * delta


func self_destruction_action():
	queue_free()

