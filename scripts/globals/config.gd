extends Node


enum PlayerConsts {
	# describe constants available for player
	SPEED = 1_000,
	BULLET_SPEED = 2_500,
	HEALTH = 1_000,
}


enum FirstStageEnemyConsts {
	SPEED = 700,
	DISTANCE_BEFORE_PLAYER = 200,
	BULLET_SPEED = 2_000,
	HEALTH = 20,
	PRIZE_FOR_KILL = 1
}


enum BulletConsts {
	DELETE_TIME = 2,
	DAMAGE = 1
}


const RANGE_BETWEEN_CAMERA_BORDER_AND_SPAWN_POINT := 100

