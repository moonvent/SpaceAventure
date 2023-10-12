extends Gun


class_name FirstStageEnemyGun


var new_bullet: Bullet

var shot_from_position_marker: Marker2D 
var player: Player
var projectiles: Node2D


var enemy: FirstStageEnemy


func init_without_params():
    projectile_scene = GlobalResourceLoader.BulletScene
    projectile_speed = Config.PlayerConsts.BULLET_SPEED
    shot_cooldown = 0

    # player = get_node("..") as Player
    # shot_from_position_marker = get_node("../ShotMarker")
    # projectiles = get_node("../../Projectiles")
    

func fire(shot_position: Vector2):
    direction = (shot_position - player.position).normalized()

    new_bullet = projectile_scene.instantiate()
    new_bullet.init(direction, shot_from_position_marker.global_position, projectile_speed)
    projectiles.add_child(new_bullet)


