extends Area2D


class_name Projectile


var SPEED: int
var direction: Vector2


func init(projectile_direction: Vector2, shot_position: Vector2):
    direction = projectile_direction
    position = shot_position
    rotation = projectile_direction.angle()


func _physics_process(delta):
    position += direction * SPEED * delta

