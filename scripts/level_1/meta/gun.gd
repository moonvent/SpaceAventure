extends Node2D


class_name Gun


# scene of the projectyle, can be a bullet, and others
var projectile_scene: PackedScene
var projectile_speed: int
var shot_cooldown: int
var direction: Vector2


func init_without_params():
    pass


func fire(shot_position: Vector2):
    """
        Describe how to fire
        Args:
            shot_position (Vector2): position which need to be selected for shooting
    """

