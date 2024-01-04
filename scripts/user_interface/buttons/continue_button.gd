extends Button


func _ready():
	if true:
		text = 'start_game'
	else:
		text = 'continue_game'


func _on_pressed():
	GlobalResourceLoader.change_scene(GlobalResourceLoader.FirstLevelScene)
