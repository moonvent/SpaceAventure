extends Node2D


class_name Level


func _ready():
	pass
	# get_tree().change_scene_to_packed(GlobalResourceLoader.GameOverScene)


func _notification(what):
	if what == NOTIFICATION_WM_CLOSE_REQUEST:
		pass

