# Tentativas de execução

### Testando comandos para rodar
```#
godot --headless --script DLL/TestMain.cs --quit

godot --headless --path ./ --remote-debug tcp://127.0.0.1:6007 --quit 

"Não sei como finalizar a execução depois de rodar este comando"
godot --path ./ --print-fps --remote-debug tcp://127.0.0.1:6007 
```

### TENTATIVAS vscode
##### launch.json
``` json
{
  "version": "0.2.0",
  "configurations": [
    {

    }

    {
      "name": "GODOT - Run and attach to debug",
      "type": "godot-mono",
      "request": "attach",
      "preLaunchTask": "gd debug server",
      "address": "${config:debug.address}",
      "port": 6007,
      "console" : "integratedTerminal",
      "stopAtEntry": true
    },

    {
      "name": "GODOT - Attach only",
      "type": "godot-mono",
      "request": "attach",
      "address": "${config:debug.address}",
      "port": "${config:debug.port}",
      "console" : "integratedTerminal",
      "stopAtEntry": true
    }
  ]
}
```

##### tasks.json
``` json
{
  "version": "2.0.0",
  "tasks": [

    { // DOTNET BUILD
      "label": "cs build",
      "type": "shell",
      "command": "dotnet",
      "args": [
        "build",
        "${workspaceFolder}\\RPG_try_2025.csproj"
      ],
      "problemMatcher": ["$msCompile"]
    },

    { // LAUNCH GODOT SERVER
      "label": "gd debug server",
      "type": "shell",
      "command": "${config:godot.path}",
      "args": [
        "--headless",
        "--path ${workspaceFolder}",
        "--remote-debug ${config:debug.address}:${config:debug.port}",
        "--print-fps",
      ],
      "dependsOn": "cs build",
      "isBackground": true,
      "problemMatcher":  [
        {
          "pattern": [
            {
              "regexp": ".",
              "file": 1,
              "location": 2,
              "message": 3
            }
          ],
          "background": {
            "activeOnStart": true,
            "beginsPattern": "Debugger listening on",
            "endsPattern": "Debugger listening on"
          }
        }
      ]
    }
  ]
}
```