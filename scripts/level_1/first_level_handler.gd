extends LevelHandler


class_name FirstLevelHandler


enum Stages {
    FIRST = 0,
    SECOND = 15,
    THIRD = 30,
    FOURTH = 60
}


var score := 0 : set = _set_score
var current_stage: int


@onready var first_level_ui: FirstLevelUserInterface = %FirstLevelUI as FirstLevelUserInterface

# here, will be score point for every stage
var available_scores_for_new_stage: Array


func _ready():
    available_scores_for_new_stage = []

    for one_stage in Stages:
        available_scores_for_new_stage.append(Stages[one_stage])


func _set_score(new_score: int):

    if available_scores_for_new_stage.has(new_score):
        current_stage = new_score

    score = new_score
    first_level_ui.change_score(score)

