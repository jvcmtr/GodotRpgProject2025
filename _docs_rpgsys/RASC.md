{

	"Default C# Class": {
	"prefix": "csclassstart",
	"isFileTemplate": true,
	"body": [
		"using System;",
		"",
		"namespace ${TM_DIRECTORY/^C:\\\\Users\\\\cicer\\\\Documents\\\\JV\\\\z - Godot\\\\Projetos\\\\GD_CS_RPG_2025(\\\\([^\\\\]+))(\\\\([^\\\\]+))?(\\\\([^\\\\]+))?(\\\\([^\\\\]+))?(\\\\([^\\\\]+))?(\\\\([^\\\\]+))?(\\\\([^\\\\]+))?(\\\\([^\\\\]+))?(\\\\([^\\\\]+))?(\\\\([^\\\\]+))?/$2${3:+.}$4${5:+.}$6${7:+.}$8${9:+.}$10${11:+.}$12${13:+.}$14${15:+.}$16${17:+.}$18${19:+.}$20/gi};",
		"",
		"public class ${TM_FILENAME_BASE} {",
		"    $0",
		"    public ${TM_FILENAME_BASE}(){",
		"    }",
		"}",
		"namespace ${RELATIVE_FILEPATH/(.cs)//g} ;",
		"namespace ${RELATIVE_FILEPATH/[\\\\]/./g} ;",
		"_ !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!",
		"namespace ${RELATIVE_FILEPATH/\\\\([^\\\\]+)$/_/g} ;",
		
		
		"_",
		"works:",
		"namespace ${RELATIVE_FILEPATH/(\\\\([^\\\\]+)$)|(\\\\)/${3:+.}/g} ;",
		"namespace ${RELATIVE_FILEPATH/(\\\\)|(.cs)/${1:+.}/g} ;",
		"namespace ${TM_DIRECTORY/(\\\\)|(C:\\\\Users\\\\cicer\\\\Documents\\\\JV\\\\z - Godot\\\\Projetos\\\\GD_CS_RPG_2025\\\\)/${1:+.}/g} ;",
		"_",
		
		"namespace ${RELATIVE_FILEPATH/[\\\\]/./g} ;",
		"namespace DLL.${TM_DIRECTORY/C:\\\\Users\\\\cicer\\\\Documents\\\\JV\\\\z - Godot\\\\Projetos\\\\GD_CS_RPG_2025\\\\DLL//g} ;",
		"namespace ${TM_DIRECTORY/C:\\\\Users\\\\cicer\\\\Documents\\\\JV\\\\z - Godot\\\\Projetos\\\\GD_CS_RPG_2025//} ;",
		"",
		"/*",
		"namespace ${RELATIVE_FILEPATH/[\\\\](\\.cs)/./g} ;",
		"namespace ${RELATIVE_FILEPATH/[\\\\]/./(\\.cs)/_/g} ;",
		"namespace ${RELATIVE_FILEPATH/[\\\\]/(\\.cs)/./_/g} ;",
		"namespace ${RELATIVE_FILEPATH/.cs/_/g; RELATIVE_FILEPATH/[\\\\]/=/g} ;",
		"${RELATIVE_FILEPATH/(.cs)/_/g/[\\\\]/AAA/g}",
		"namespace ${TM_DIRECTORY/^/${1:/replace(/[^\\w]/_/g)}} ;",
		"namespace ${TM_DIRECTORY/[\\\\]|(\\.cs)/./g} ;",
		"namespace ${ ${RELATIVE_FILEPATH/[\\\\]/./g}/[c]//} ;",
		"namespace ${RELATIVE_FILEPATH/(.cs)//[\\\\]/./g} ;",
		"*/",
		"",
	],
	"description": "C# class with dynamic class name from file"
	}

}