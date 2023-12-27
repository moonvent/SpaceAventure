extends Projectile


class_name Bullet


func _init():
	# damage = Config.BulletConsts.DAMAGE
	damage = Constant.GunPrimaryStats.BulletDamage
	speed = Constant.GunPrimaryStats.BulletSpeed


func _on_body_entered(body):
	if body is SpaceShip:
		body.decrease_health(damage)

	queue_free()
