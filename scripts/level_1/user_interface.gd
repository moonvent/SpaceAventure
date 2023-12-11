extends Control


class_name FirstLevelUserInterface


@onready var hp_amount: Label = %HpAmount
@onready var score: Label = %Score


func _ready():
	pass 


func change_hp_amount(new_hp_amount: int):
	hp_amount.text = str(new_hp_amount)
	
	
func change_score(new_score: int):
	score.text = str(new_score).pad_zeros(3)

