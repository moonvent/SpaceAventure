extends Node2D


class_name SpaceField


var score := 0 : set = _set_score
var current_stage: int


# @onready var first_level_ui: FirstLevelUserInterface = %FirstLevelUI as FirstLevelUserInterface

# here, will be score point for every stage
var available_scores_for_new_stage: Array

var new_rounded_score := 0  # a number which represent status of score in level, do we need change stage or not


func _ready():
	available_scores_for_new_stage = []

	for one_stage in Constant.Stages:
		available_scores_for_new_stage.append(Constant.Stages[one_stage])


func _set_score(new_score: int):

	new_rounded_score = floor(new_score / Constant.MULTIPLIER_FOR_ROUND_FOR_UPDATE_STAGE) * Constant.MULTIPLIER_FOR_ROUND_FOR_UPDATE_STAGE
	if available_scores_for_new_stage.has(new_rounded_score):
		current_stage = new_rounded_score

	score = new_score
	# first_level_ui.change_score(score)

