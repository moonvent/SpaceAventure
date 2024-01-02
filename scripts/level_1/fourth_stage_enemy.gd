extends Enemy


class_name FourthStageEnemy


func init_without_params():
	speed = Config.FourthStageEnemyConsts.SPEED
	health = Config.FourthStageEnemyConsts.HEALTH
	prize_for_kill = Config.FourthStageEnemyConsts.PRIZE_FOR_KILL
	gun = GlobalResourceLoader.FourthStageEnemyGun.instantiate()
	super()


func decrease_health(decrease_amount: int):
	super(decrease_amount)


func death():
	super()

