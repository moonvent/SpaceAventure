extends Projectile


class_name Bullet


func _ready():
	damage = Config.BulletConsts.DAMAGE


func _on_body_entered(body):
	if body is SpaceShip:
		body.decrease_health(damage)

	queue_free()
