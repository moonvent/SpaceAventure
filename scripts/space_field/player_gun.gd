extends Gun


class_name PlayerGun


func init(player_instance: Player):
	shot_marker = player_instance.get_node(Constant.NodeTitle.ShotMarker)
	player = player_instance


func _ready():
	projectiles = player.get_node('../%s' % Constant.NodeTitle.Projectiles)
	

func fire(shot_position: Vector2):
	direction = (shot_position - player.position).normalized()

	bullet = SceneLoader.BulletScene.instantiate()
	bullet.init(direction, shot_marker.global_position)
	projectiles.add_child(bullet)

