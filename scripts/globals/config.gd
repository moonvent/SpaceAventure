extends Node


enum PlayerConsts {
	# describe constants available for player
	SPEED = 1_000,
	BULLET_SPEED = 2_500,
	HEALTH = 1_000,
}


enum FirstStageEnemyConsts {
	SPEED = 700,
	DISTANCE_BEFORE_PLAYER = 100,
	BULLET_SPEED = 2_000,
	HEALTH = 5,
	PRIZE_FOR_KILL = 1,
	BULLET_CLIP = 3,
	MAX_DISTANCE_FOR_MIN_REWARD = 600
}


enum SecondStageEnemyConsts {
	SPEED = 800,
	DISTANCE_BEFORE_PLAYER = 50,
	BULLET_SPEED = 2_500,
	HEALTH = 10,
	PRIZE_FOR_KILL = 3,
	BULLET_CLIP = 5
}


enum ThirdStageEnemyConsts {
	SPEED = 1000,
	DISTANCE_BEFORE_PLAYER = 300,
	BULLET_SPEED = 3_000,
	HEALTH = 15,
	PRIZE_FOR_KILL = 20,
	BULLET_CLIP = 10
}


enum FourthStageEnemyConsts {
	SPEED = 700,
	DISTANCE_BEFORE_PLAYER = 100,
	BULLET_SPEED = 2_500,
	HEALTH = 200,
	PRIZE_FOR_KILL = 50,
	BULLET_CLIP = 1,
	BULLET_DAMAGE = 5
}


enum BulletConsts {
	DELETE_TIME = 2,
	DAMAGE = 1
}


const RANGE_BETWEEN_CAMERA_BORDER_AND_SPAWN_POINT := 100


enum Stages {
	FIRST = 0,
	SECOND = 15,
	THIRD = 30,
	FOURTH = 60
}


enum SpawnSide {
	UP,
	RIGHT,
	DOWN,
	LEFT
}



