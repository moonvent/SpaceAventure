extends SpaceShip


class_name Enemy


var player: Player


func _ready():
    super()
    player = get_node("../../Player") as Player
