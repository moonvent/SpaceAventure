extends SpaceShip


class_name Enemy


@onready var first_level_handler: FirstLevelHandler

var player: Player

var prize_for_kill: int


var min_distance_for_max_reward := Config.FirstStageEnemyConsts.DISTANCE_BEFORE_PLAYER
var max_distance_for_min_reward := Config.FirstStageEnemyConsts.MAX_DISTANCE_FOR_MIN_REWARD


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
	first_level_handler.score += calculate_enemy_reward(prize_for_kill)
	super()


func calculate_enemy_reward(max_prize_for_kill):
	"""
	This function need to calculate reward
	"""
	var died_place_distance := global_position.distance_to(player.global_position)
	var part_for_every_point: float = (max_distance_for_min_reward - min_distance_for_max_reward) / max_prize_for_kill
	var distance_for_prize_point := part_for_every_point
	
	while max_prize_for_kill >= 1 and died_place_distance > distance_for_prize_point:
		max_prize_for_kill -= 1
		distance_for_prize_point += part_for_every_point
	
	return max_prize_for_kill

