extends SpaceShip


const BulletScene: PackedScene = preload("res://scenes/level_1/bullet.tscn")
@onready var shot_from_position_marker := $ShotMarker


var direction: Vector2          # direction of ship, or bullet
var global_mouse_pos            # mouse pos on the card
var new_bullet: Bullet


func _ready():
    SPEED = 500


func _physics_process(_delta):
    global_mouse_pos = get_global_mouse_position()
    _look_at_position(global_mouse_pos)

    direction = Input.get_vector("left", "right", "up", "down")
    moving(direction)
    
    if (Input.is_action_pressed("fire")):
        fire()


func fire():
    global_mouse_pos = get_global_mouse_position()
    direction = (global_mouse_pos - position).normalized()

    new_bullet = BulletScene.instantiate()
    new_bullet.init(direction, shot_from_position_marker.global_position)
    %Projectiles.add_child(new_bullet)


