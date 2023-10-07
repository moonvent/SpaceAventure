extends Projectile


class_name Bullet


func init(projectile_direction: Vector2, shot_position: Vector2):
    SPEED = 1500
    super(projectile_direction, shot_position)
