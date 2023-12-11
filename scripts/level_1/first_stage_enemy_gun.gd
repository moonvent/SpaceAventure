extends EnemyGun


class_name FirstStageEnemyGun


@onready var shot_queue_activator: Timer = $ShotQueueActivator
var reloaded_amount_of_charges := 3


func init_without_params():
	projectile_scene = GlobalResourceLoader.BulletScene
	projectile_speed = Config.FirstStageEnemyConsts.BULLET_SPEED
	shot_cooldown = 0

	player = get_node("../../../Player") as Player
	enemy = get_node("..")
	shot_from_position_marker = get_node("../ShotMarker")
	projectiles = get_node("../../../Projectiles")
	

func fire(shot_position: Vector2):
	direction = (shot_position - enemy.position).normalized()

	new_bullet = projectile_scene.instantiate()
	new_bullet.init(direction, shot_from_position_marker.global_position, projectile_speed)
	projectiles.add_child(new_bullet)


func _on_shot_cooldown_timeout():
	shot_queue_activator.start()
	reloaded_amount_of_charges = 3


func _on_shot_queue_activator_timeout():
	fire(player.position)
	reloaded_amount_of_charges -= 1

	if not reloaded_amount_of_charges:
		shot_queue_activator.stop()
