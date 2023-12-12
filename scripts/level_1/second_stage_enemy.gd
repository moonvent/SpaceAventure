extends Enemy


class_name SecondStageEnemy


func init_without_params():
	speed = Config.SecondStageEnemyConsts.SPEED
	health = Config.SecondStageEnemyConsts.HEALTH
	prize_for_kill = Config.SecondStageEnemyConsts.PRIZE_FOR_KILL
	gun = GlobalResourceLoader.SecondStageEnemyGun.instantiate()
	super()

