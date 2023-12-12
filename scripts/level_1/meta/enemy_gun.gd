extends Gun


class_name EnemyGun


var enemy
var enemy_config


func init_without_params():
	# before call it we need to setup enemy_config
	projectile_scene = GlobalResourceLoader.BulletScene
	projectile_speed = enemy_config.BULLET_SPEED

	player = get_node("../../../Player") as Player
	enemy = get_node("..")
	shot_from_position_marker = get_node("../ShotMarker")
	projectiles = get_node("../../../Projectiles")

