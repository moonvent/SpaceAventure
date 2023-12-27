extends Node2D


class_name Gun


var direction: Vector2

var shot_marker: Marker2D 

var bullet: Bullet

var player: Player

# projectile storage
var projectiles: Node


func fire(shot_position: Vector2):
	"""
		Describe how to fire
		Args:
			shot_position (Vector2): position which need to be selected for shooting
	"""

