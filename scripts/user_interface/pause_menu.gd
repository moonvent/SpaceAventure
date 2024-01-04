extends CanvasLayer


class_name PauseMenu


@onready var first_level_handler: FirstLevelHandler = %FirstLevelHandler


func _ready():
	visible = false


func _on_resume_button_pressed():
	first_level_handler.toggle_pause()
