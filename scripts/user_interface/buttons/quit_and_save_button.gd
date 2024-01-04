extends Button


func _on_pressed():
	SaveAction.send_request_to_quit()
