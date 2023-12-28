extends SpaceShip


class_name Enemy


var player: Player

var kill_reward: int

var config


func init(player_instance: Player):
	# add_child(gun)
	# gun.init_without_params()

	speed = config.Speed
	health = config.Health
	kill_reward = config.KillReward
	# gun = GlobalResourceLoader.FirstStageEnemyGun.instantiate()

	player = player_instance


func _physics_process(_delta):
	_look_at_position(player.position)

	direction = (player.global_position - global_position).normalized()

	if self.global_position.distance_to(player.global_position) > 100:
		moving(direction)


func death():
	# first_level_handler.score += calculate_enemy_reward(prize_for_kill)
	super()
