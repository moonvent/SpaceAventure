extends Node2D


func _ready():
	# TranslationServer.set_locale('ru')
	print(TranslationServer.get_locale())
	print(tr('asb'))
	print(tr('Hello world!'))
	print(tr('Game Over'))
	pass



