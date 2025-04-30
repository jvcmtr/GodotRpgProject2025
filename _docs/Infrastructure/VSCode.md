### Tentativa bem sucedida de execução E debug

##### launch.json
``` json
{
  "version": "0.2.0",
  "configurations": [
    {
      "name": "Run headless",
      "type": "coreclr",
      "request": "launch",
      "preLaunchTask": "cs build",
      "program": "${config:godot.path}",
      "args": [
        "--headless",
        "--script", 
        "DLL/TestMain.cs",
        "--quit"
      ],
      "cwd": "${workspaceFolder}",
      "console": "integratedTerminal"
    },
  ]
}
```

##### tasks.json
```json
{
  "version": "2.0.0",
  "tasks": [
    {
      "label": "cs build",
      "type": "shell",
      "command": "dotnet",
      "args": [
        "build",
        "${workspaceFolder}\\RPG_try_2025.csproj"
      ],
      "problemMatcher": ["$msCompile"]
    }
  ]
}
```

## Explicação
EU ACHO que os breakpoints de debug do vscode de fato pararam o codigo e funcionaram por conta do `"type": "coreclr",` que é o tipo de debbugger do dotnet (em vez de godot, mono ou outras que eu tentei).

Passei muito tempo tentando conectar ao debug-server do godot atravéz do port mas não funcionou

##### Obs
- o `--quit` é nescessario 
- é importante que o arquivo DLL\TestMain.cs herde a classe SceneTree para que possa ser executado diretamente como script