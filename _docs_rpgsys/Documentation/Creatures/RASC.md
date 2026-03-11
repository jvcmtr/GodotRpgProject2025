#### Interface Creature
Fazer classe generica? Criaturas definidas por conjuntos de traits/configuracoes? Exemplo:
- Tem Garras
- Cospe Fogo
- É sonnolenta
- É Amigavel

Fazer logica de levelup automatico de stats de criaturas? skilltree para criaturas?

Classes com contrutures especializados para cada criatura:
- Monster (todo o resto, pode ser separado se nescessario, mas o ideal seria fazer composicao com enums )
- Animal (sem magia, sem nada demais)
- Construct
- Humanoid (tem equipamento)
#### Enum Creature Behaviour
State machine para o comportamento geral (quando entrar/sair de um macroestado). Scripts sequenciais para a logica interna de um estado.

```
BehaviourStateMachine: // Enum de implementacoes default (Como responde ao player) 
	DoSleeps?
	CrossesWatter?
	StaysCloseToSpawn // enum proximidade
	lose agro when enemy flee
	Warns before attack
	AttacksOnly creature enters territory // enum proximidade
	Attacks when sees enemy
	Flees when sees enemy
	...when sees creature
	...when sees prey
	...when sees sameTypeCreature
	FleesOnLowHealth // Enum: never, on low, on medium, on any damage, emidiately
	 
CombatLogic[] // Logica quando em combate
SearchingLogic[] // Logica quando procurando 
WanderingLogic[] // ...
IdleLogic[] //...

```

#### Enum CreatureAligeance
Grupos de creature types e creature aligeances com exclusoes pontuais? Esquema
 `empresa>departamento>subdepartamento>usuario`
 `CreatureAligeance>CreatureAligeance>CreatureType`
```
Parent Aligeance
```