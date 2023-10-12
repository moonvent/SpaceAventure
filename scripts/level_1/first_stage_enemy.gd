extends Enemy


class_name FirstStageEnemy


func _setup_gun():
    gun = GlobalResourceLoader.FirstStageEnemyGun.instantiate()
    add_child(gun)
    gun.init_without_params()


func _ready():
    super()
    speed = Config.FirstStageEnemyConsts.SPEED


func _physics_process(_delta):
    _look_at_position(player.position)

    direction = (player.global_position - global_position).normalized()

    moving(direction)

