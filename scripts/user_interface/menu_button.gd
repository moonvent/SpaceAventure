extends Control

@export var button_text: String
@export var icon_texture: Texture
@export var key_texture: Texture

@onready var icon: TextureRect = $HBoxContainer/Icon
@onready var text: Label = $HBoxContainer/Label
@onready var key: TextureRect = $HBoxContainer/Key


func _ready():
    text.text = button_text
    icon.texture = icon_texture
    key.texture = key_texture

