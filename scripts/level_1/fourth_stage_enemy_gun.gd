extends EnemyGun


class_name FourthStageEnemyGun


var second_shot_marker: Marker2D


func init_without_params():
	enemy_config = Config.FourthStageEnemyConsts
	second_shot_marker = get_node('../ShotMarker2')
	super()


func fire(shot_position: Vector2):
	direction = (shot_position - enemy.position).normalized()

	for shot_marker in [shot_from_position_marker, second_shot_marker]:
		new_bullet = projectile_scene.instantiate()
		new_bullet.init(direction, shot_marker.global_position, projectile_speed)
		projectiles.add_child(new_bullet)
		new_bullet.damage = enemy_config.BULLET_DAMAGE
		await get_tree().create_timer(0.2).timeout

