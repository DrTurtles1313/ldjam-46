extends Control

onready var fade = $Fade
onready var bg = $"BGs(L3)/BG"
onready var popup = $"Minigame(L6)/Popup"

enum ENDSTATE {
	NOATTEMPT, # no repair attempt was made, minigame was left
	BOTCH, # brings system online, damages efficiency
	PASSABLE, # only brings system online
	SUCCESS # brings system online, restores efficiency
}

# When we enter the scene tree, do the fadey background magic
func _ready():
	print("tweening")
	fade.interpolate_property(bg, "color", bg.color, Color(0.082353, 0.082353, 0.082353, 0.7), 1.9)
	fade.start()
	pass # Replace with function body.

func _on_minigame_enter(difficulty):
	print("test minigame entered with difficulty: ", difficulty)

func WinButtonPressed():
	print("test minigame ended. cause: Win Button. endstate: ", ENDSTATE.SUCCESS)
	emit_signal("minigame_exit", ENDSTATE.SUCCESS);
	self.queue_free() # delete the minigame since we ended it all.

signal minigame_exit(SucessState)
# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass


func FadeAllComplete():
	popup.popup_centered()
	pass # Replace with function body.


func BG_gui_input(event: InputEvent):
	if event is InputEventMouseButton and event.button_mask == BUTTON_LEFT:
		print("test minigame ended. cause: BG clicked. endstate: ", ENDSTATE.NOATTEMPT)
		emit_signal("minigame_exit", ENDSTATE.NOATTEMPT);
		self.queue_free()
