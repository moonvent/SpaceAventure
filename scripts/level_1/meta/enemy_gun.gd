extends Gun


class_name EnemyGun


var enemy
var enemy_config


@onready var shot_queue_activator: Timer = $ShotQueueActivator
var reloaded_amount_of_charges: int 


func init_without_params():
	# before call it we need to setup enemy_config
	projectile_scene = GlobalResourceLoader.BulletScene
	projectile_speed = enemy_config.BULLET_SPEED

	player = get_node("../../../Player") as Player
	enemy = get_node("..")
	shot_from_position_marker = get_node("../ShotMarker")
	projectiles = get_node("../../../Projectiles")
	reloaded_amount_of_charges = enemy_config.BULLET_CLIP


func fire(shot_position: Vector2):
	direction = (shot_position - enemy.position).normalized()

	new_bullet = projectile_scene.instantiate()
	new_bullet.init(direction, shot_from_position_marker.global_position, projectile_speed)
	projectiles.add_child(new_bullet)


func _on_shot_cooldown_timeout():
	shot_queue_activator.start()
	reloaded_amount_of_charges = enemy_config.BULLET_CLIP


func _on_shot_queue_activator_timeout():
	fire(player.position)
	reloaded_amount_of_charges -= 1

	if not reloaded_amount_of_charges:
		shot_queue_activator.stop()
