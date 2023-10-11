extends Area2D


class_name Projectile


var speed: int
var direction: Vector2


func init_without_params():
    pass


func init(projectile_direction: Vector2, shot_position: Vector2, projectile_speed: int):
    init_without_params()
    direction = projectile_direction
    position = shot_position
    rotation = projectile_direction.angle()
    speed = projectile_speed


func _physics_process(delta):
    position += direction * speed * delta

