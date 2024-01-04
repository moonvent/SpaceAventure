extends LevelHandler


class_name FirstLevelHandler


var score := 0 : set = _set_score
var current_stage: int


@onready var first_level_ui: FirstLevelUserInterface = %FirstLevelUI as FirstLevelUserInterface
var level: Level

# here, will be score point for every stage
var available_scores_for_new_stage: Array

const MULTIPLIER := 5       # a number which need for rounding a current score
var new_rounded_score := 0  # a number which represent status of score in level, do we need change stage or not

var paused: bool = false


func _ready():
	level = get_node('..')
	available_scores_for_new_stage = []

	for one_stage in Config.Stages:
		available_scores_for_new_stage.append(Config.Stages[one_stage])


func _set_score(new_score: int):

	new_rounded_score = floor(new_score / MULTIPLIER) * MULTIPLIER
	if available_scores_for_new_stage.has(new_rounded_score):
		current_stage = new_rounded_score

	score = new_score
	first_level_ui.change_score(score)


func toggle_pause():
	get_tree().paused = !get_tree().paused
	paused = get_tree().paused
	%PauseMenu.visible = paused


func _input(_event):
	if (Input.is_action_pressed("pause")):
		toggle_pause()
