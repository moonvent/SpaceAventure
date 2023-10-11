extends Gun


class_name PlayerGun


const BulletScene: PackedScene = preload("res://scenes/level_1/bullet.tscn")
var shot_from_position_marker: Marker2D 
var player: Player
var new_bullet: Bullet
var projectiles: Node2D


func init_without_params():
    projectile_scene = BulletScene
    projectile_speed = Config.PlayerConsts.BULLET_SPEED
    shot_cooldown = 0
    

func init(player_object: Player, player_shot_marker: Marker2D, projectiles_node: Node2D):
    player = player_object
    shot_from_position_marker = player_shot_marker
    projectiles = projectiles_node
    init_without_params()


func fire(shot_position: Vector2):
    direction = (shot_position - player.position).normalized()

    new_bullet = BulletScene.instantiate()
    new_bullet.init(direction, shot_from_position_marker.global_position, projectile_speed)
    projectiles.add_child(new_bullet)


