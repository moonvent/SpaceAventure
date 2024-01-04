extends CanvasLayer


class_name GameOverMenu


func _on_save_and_quit_button_pressed():
	SaveAction.send_request_to_quit()


func _on_again_button_pressed():
	GlobalResourceLoader.change_scene(GlobalResourceLoader.FirstLevelScene)
