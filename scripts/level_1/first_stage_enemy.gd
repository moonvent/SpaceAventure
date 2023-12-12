extends Enemy


class_name FirstStageEnemy


func init_without_params():
	speed = Config.FirstStageEnemyConsts.SPEED
	health = Config.FirstStageEnemyConsts.HEALTH
	prize_for_kill = Config.FirstStageEnemyConsts.PRIZE_FOR_KILL
	gun = GlobalResourceLoader.FirstStageEnemyGun.instantiate()
	super()


