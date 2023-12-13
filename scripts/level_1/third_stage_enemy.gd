extends Enemy


class_name ThirdStageEnemy


func init_without_params():
	speed = Config.ThirdStageEnemyConsts.SPEED
	health = Config.ThirdStageEnemyConsts.HEALTH
	prize_for_kill = Config.ThirdStageEnemyConsts.PRIZE_FOR_KILL
	gun = GlobalResourceLoader.ThirdStageEnemyGun.instantiate()
	super()

