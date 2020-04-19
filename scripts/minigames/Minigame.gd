extends Control


# Declare member variables here. Examples:
# var a = 2
# var b = "text"


# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.

func _on_minigame_enter(difficulty):
	print("test: ", difficulty)
	emit_signal("minigame_exit", 3);

signal minigame_exit(SucessState)
# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass
