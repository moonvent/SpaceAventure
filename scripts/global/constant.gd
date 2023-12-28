const Action := {
    'Up' : 'Up',
    'Down' : 'Down',
    'Left' : 'Left',
    'Right' : 'Right',
    'Fire' : 'Fire',
    'Pause' : 'Pause',
}


const NodeTitle := {
    'ShotMarker': 'ShotMarker',
    'Projectiles': 'Projectiles'
}


const PlayerPrimaryStats := {
    'Health': 150,
    'Speed': 1_500,
}


const GunPrimaryStats := {
    'BulletSpeed': 3_000,
    'BulletDamage': 1
}


enum SpawnSide {
    Up,
	Right,
	Down,
	Left
}


enum Stages {
	First = 0,
	Second = 15,
	Third = 30,
	Fourth = 60
}


const MULTIPLIER_FOR_ROUND_FOR_UPDATE_STAGE := 5		# a number which need for rounding a current score


enum Enemy1Param {
	Speed = 700,
	DistanceBeforePlayer = 100,
	BulletSpeed = 2_000,
	Health = 5,
	KillReward = 1,
	BulletClip = 3,
}
