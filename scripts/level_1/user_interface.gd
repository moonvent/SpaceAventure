extends Control


class_name FirstLevelUserInterface


@onready var hp_amount := %HpAmount


func _ready():
    pass 


func change_hp_amount(new_hp_amount: int):
    hp_amount.text = str(new_hp_amount)



