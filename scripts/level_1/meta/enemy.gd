extends SpaceShip


class_name Enemy


@onready var first_level_handler: FirstLevelHandler

var player: Player

var prize_for_kill: int


func init_without_params():
	first_level_handler = get_node("../../FirstLevelHandler")
	add_child(gun)
	gun.init_without_params()


func _ready():
	player = get_node("../../Player") as Player
	init_without_params()


func _physics_process(_delta):
	_look_at_position(player.position)

	direction = (player.global_position - global_position).normalized()

	if self.global_position.distance_to(player.global_position) > gun.enemy_config.DISTANCE_BEFORE_PLAYER:
		moving(direction)


func death():
	super()
	print(self.global_position.distance_to(player.global_position))
	first_level_handler.score += prize_for_kill

