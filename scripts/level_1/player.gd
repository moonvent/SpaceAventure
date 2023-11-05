extends SpaceShip


class_name Player


@onready var first_level_ui: FirstLevelUserInterface = %FirstLevelUI as FirstLevelUserInterface


func _setup_gun():
    gun = GlobalResourceLoader.PlayerGunScene.instantiate()
    add_child(gun)
    gun.init_without_params()


func init_without_params():
    speed = Config.PlayerConsts.SPEED
    health = Config.PlayerConsts.HEALTH


func _ready():
    super()
    init_without_params()


func _physics_process(_delta):

    look_at_position_coords = get_global_mouse_position()
    _look_at_position(look_at_position_coords)

    direction = Input.get_vector("left", "right", "up", "down")
    moving(direction)
    
    if (Input.is_action_pressed("fire")):
        gun.fire(look_at_position_coords)


func decrease_health(decrease_amount: int):
    super(decrease_amount)
    first_level_ui.change_hp_amount(health)
