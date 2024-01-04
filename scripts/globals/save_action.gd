extends Node


func _notification(what):
    if what == NOTIFICATION_WM_CLOSE_REQUEST:
        print('save and quit')
        save_game_process()
        get_tree().quit()


func save_game_process():
    """
    Save generally game proccess, save scene and some data if it's gameplay scene
    """


func save_scene():
    pass


func send_request_to_quit():
    """
    Send request to all nodes about exit from game
    """
    get_tree().root.propagate_notification(NOTIFICATION_WM_CLOSE_REQUEST)
