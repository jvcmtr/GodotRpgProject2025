@tool
extends EditorPlugin

var custom_types = []

const SCAN_FOLDER := "res://DLL/nodes"
const FILES_SUFIX := ".cs"
const NODE_PREFIX := "DLL_"
const DEFAULT_ICON := preload("res://assets/cs.png") # Replace with your own icon

# Register when the plugin is enabled
func _enter_tree():
	scan_and_register_nodes()
	# Connect the signal to update when the project is reloaded or rebuilt
	EditorInterface.get_resource_filesystem().filesystem_changed.connect(_on_editor_opened)

# Unregister when the plugin is disabled
func _exit_tree():
	clear_custom_types()
	EditorInterface.get_resource_filesystem().filesystem_changed.disconnect(_on_editor_opened)

func scan_and_register_nodes():
	var dir = DirAccess.open(SCAN_FOLDER)
	if dir:
		dir.list_dir_begin()
		var file_name = dir.get_next()
		while file_name != "":
			if file_name.ends_with(FILES_SUFIX):
				var script_path = SCAN_FOLDER + "/" + file_name
				var type_name = NODE_PREFIX + file_name.replace(FILES_SUFIX, "")
				var script = load(script_path)
				if script is Script:
					var base_type = script.get_instance_base_type()
					if base_type != "":
						add_custom_type( type_name, base_type, script, DEFAULT_ICON)
						custom_types.append(type_name)
			file_name = dir.get_next()
		dir.list_dir_end()


func clear_custom_types():
	for type_name in custom_types:
		remove_custom_type(type_name)
	custom_types.clear()

# Callback to refresh when the editor reloads (after a rebuild)
func _on_editor_opened():
	clear_custom_types()
	# We only want to rescan if the directory was modified (e.g., after rebuild)
	scan_and_register_nodes()
