extends SpaceShip


class_name Player


var direction: Vector2          # direction of ship, or bullet
var global_mouse_pos            # mouse pos on the card
var new_bullet: Bullet


func _ready():
    GunScene = preload("res://scenes/level_1/player_gun.tscn")

    SPEED = Config.PlayerConsts.SPEED
    gun = GunScene.instantiate()
    gun.init(self, $ShotMarker, %Projectiles)
    add_child(gun)


func _physics_process(_delta):
    global_mouse_pos = get_global_mouse_position()
    _look_at_position(global_mouse_pos)

    direction = Input.get_vector("left", "right", "up", "down")
    moving(direction)
    
    if (Input.is_action_pressed("fire")):
        gun.fire(get_global_mouse_position())
        # print(%Projectiles)

