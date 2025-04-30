extends Node2D
# This script only pourpose is to connect with the c# TestMain Class and call its default method 

# Gets the c# 'Main' class
@onready var CSTestNode = %CS_Hook

func _ready():
	CSTestNode.runTests()

func _run():
	CSTestNode.runTests()
	get_tree().quit()
