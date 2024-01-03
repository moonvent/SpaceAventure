extends Node2D


func _ready():
	TranslationServer.set_locale('ru')
	get_tree().change_scene_to_packed(GlobalResourceLoader.GameOverScene)



