extends Enemy


class_name FirstStageEnemy


func _setup_gun():
    gun = GlobalResourceLoader.FirstStageEnemyGun.instantiate()
    add_child(gun)
    gun.init_without_params()


func init_without_params():
    speed = Config.FirstStageEnemyConsts.SPEED
    health = Config.FirstStageEnemyConsts.HEALTH


func _ready():
    super()
    player = get_node("../../Player") as Player
    init_without_params()


func _physics_process(_delta):
    _look_at_position(player.position)

    direction = (player.global_position - global_position).normalized()

    if self.global_position.distance_to(player.global_position) > Config.FirstStageEnemyConsts.DISTANCE_BEFORE_PLAYER:
        moving(direction)

