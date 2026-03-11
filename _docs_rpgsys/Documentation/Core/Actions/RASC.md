#### Interface Actor
personagem, criatura que age. 
Possui `getPossibleActions() -> ActionMetadata` : Set (ignora duplicatas)
Possui `useAction( ActionMetadata )`
Possui `addAction( actionMetadata )`

```
// Actor

IActionProviders -> Lista de provedores de acao
IActionSources -> Lista de 

// Calcula as acoes possiveis com base em IActionSources
// retorna ActionMetadata[], um Set (ignora duplicatas)
getPossibleActions() 

// Chama a fonte da acao e chama a pipeline de composicao da action
useAction( ActionMetadata ) 

addActionSource( actionSource )
removeActionSource( actionSource )
addActionProvider( actionProvider )
removeActionProvider( actionProvider )
```

#### ActionMetadata
```
	ActionMetadata<T> -> Onde T implementa IAction

Metadados
	Nome
	Descricao
	Imagem
	Cor
	
Para o contrutor
	Fonte -> IActionSource
	Provedor -> IActionProvider (normalmente null, é a propria fonte)
	Create() -> Função que cria uma action T
	
canPerform[]: // AND
	requiresWeaponType[] // WeaponType equiped  OR
	requiresAmmunition[] // AmmunitionType equiped OR
	requiresEquipamentWithName[] // String (nome de item no inventario) OR
	requiresEquipamentWithFlag[] // String (flags no inventario) OR
	requiresActorCondition[] // FK ActorCondition OR
	defaultRequirements[] // Enum, validacoes padrao (peso, estar na agua, etc...)
	// Talvez mais algumas condicoes para criaturas
	

```

#### Interface ActionSource
Classe que fornesce `ActionMetadata` para um `Actor`
```
interface IActionSource

CreateAction( Action )
GetAvailableActions() -> Action[]
```

#### Interface ActionProvider
Classe que fornesce actions para outras classes.
###### Exemplos:
- Uma Skill fornesce uma acao "corte duplo" para armas do tipo "espada-curva" e "katana"
- Um Escudo fornesce uma acao "contra-ataque" para armas do tipo "lança" e "rapieira"

Sendo assim, em ambos os casos a arma continua sendo a `ActionSource` da action, ou seja, atributos como o "dano" do ataque ainda serão feitos com base na arma.
```
getProvidedActions() -> ActionMetadata
provideTo( ActionSource )
```

#### Interface Action
Actions podem ser inatas ou fornescidas a Actors.
Ações sempre possuem uma fonte , ou seja, a classe que chamou o contrutor da action (arma, habilidade, magia, ou a propria criatura/objeto). 

Cada ator é responsável por definir um pipeline para a action, da sua criação até a sua execução. Por exemplo:

Um player possui uma habilidade X que possibilita uma ação de ataque melee. a habilidade, chama o metodo `addAction()` do player (ator) e passa o um conjunto de metadados da action. 
Quando outro trecho de codigo (UI, EnemyAI) chama o metodo  `useAction()` o player é responsavel por:
	1. Validar se a action pode ser usada naquele momento
	2. Chamar o metodo `Create` da `ActionMetadata` passada como parametro no metodo;
	3. 
##### Implementações
> [!note] Algumas das implementações da interface na verdade servem só como padrões de construtores para os `ActionEffects` da `BaseAction`. Incluem logica para inferir valores como apontado em `ActionEffects`

- BaseAction
- SummonSingleAction
- MeleeAttackAction
- ProjectileAttackAction
- SelfApplyAction
- MoveAction
- CompoundAction
- ComplexAction (definida em codigo, disponivel em um enum)

###### Class BaseAction
```
// BaseAction

// Isso aqui tem que ser bem otimizado
onActionEffects[] - lista de ActionEffects

// PRINCIPALMENTE ISSO
canPerform[]: // AND
	requiresWeaponType[] // WeaponType equiped  OR
	requiresAmmunition[] // AmmunitionType equiped OR
	requiresEquipamentWithName[] // String (nome de item no inventario) OR
	requiresEquipamentWithFlag[] // String (flags no inventario) OR
	requiresActorCondition[] // FK ActorCondition OR
	defaultRequirements[] // Enum, validacoes padrao (peso, estar na agua, etc...)
	// Talvez mais algumas condicoes para criaturas
```
###### Class SummonAction
> [!question] 
> Sumonar multiplas criaturas pode ser feito usando um compound action
> 
> Talvez valha a pena criar um SummonMultiple para facilitar a criacao deste tipo de action e não precisar multiplicar alguns valores que poderiam ser reutilizados, como Locale,  DefaultState, AttributeGroupSetter, etc...

```
ActionEffects[] // Herdado de BaseAction

SummonedEntity
	Reference - FK para a entidade spawnada (objeto/critura)
	DefaultState - Estado inicial da entidade (agressivo, pacific, etc...)
	Aligence - Aliado ao player, aos inimigos, neutro, agressivo
	AttributeGroupSetter< Atributos_de_criatura > 
	
SummonLocale:
	Relative Direction (facing)
	Is Position Binded To Parent (bool)
	Distance (from parent)
	Random Offset (cria em algum lugar dentro da area)
	*On position Impossible - 
		BEHAVIOUR (enum)
		maximum distance from origin
		onCreateEffects (Particles, hitboxes, ActionEffects)

```

###### Class MeleeAttackAction
```
Type = Melee (pode ser sobreescrito)
ActionEffects[] // Herdado de BaseAction

Atributos:
	// Atributos como range, damage, scale etc...
	AttributeGroupSetter< Atributos_De_Armas > 

AttackModifiers:
	addAttackConditions[]
	removeAttackConditions[]
```

###### Class ProjectileAttackAction
```
Type = Melee (pode ser sobreescrito)
ActionEffects[] // Herdado de BaseAction

Atributos:
	// Atributos como range, damage, scale etc...
	AttributeGroupSetter< Atributos_De_Armas > 

AttackModifiers:
	addAttackConditions[]
	removeAttackConditions[]
```
#### Compound Action
Podemos adaptar essa estrutura de random para `Random<T>` nesse caso, `T` seria `IAction`
```
// Agrupa multiplas acoes

Actions[] // Sempre acontece independentemente de ser random ou não

Random:
	isRandom?
	number of times chosen
	same result limit (int) // Numero maximo de vezes que um mesmo resultado pode ser escolhido. Se for negativo, permite duplicados sempre

RandomOutcomes[]:
	Action[] // um outcome pode ter multiplas actions associadas
	weight // int, probabilidade
	same result limit // Numero maximo de vezes que este resultado pode ser escolhido. Se for negativo, permite duplicados sempre, se for zero, sera sobreescrito com o valor de Random.same_result_limit 

```


#### Struct ActionEffect

> [!note] Talvez um nome melhor seja `InWorldEffect`. Pode ser uma interface que possui implementação especifica para 2d / 3d dependendo da engine
 
> [!warning]
> Precisa ser contruida em runtime por conta das seguintes questões: 
> - Como eu faço para dinamicamente spawnar particulas de fogo quando o ataque é de fogo?
> - Como spawno uma criatura com stats relativos aos meus?). 
> 
> Podem ter templates na base de dados que serão sobreescritos em runtime

#### PrebuildActionEffect
```
// PrebuildActionEffect
// Grupo de onTargetEffects para facilitar o building de acoes. Imagino eu que qualquer acao tenha multiplos ActionEffects.

Por exemplo:
	Explosão de fogo, é um effect que spawna 3 entidades (que normalmente são usadas juntas:
	uma bola de fogo, 
	particulas de fogo
	e uma textura de chamas no chão por alguns segundos
```

```
// ActionEffect (Reaction/Consequence to an action)
*ScreenEffects
	// Parametros para afetar a camera

*TargetMove -
	Relative Direction (facing)
	Animation
	Distance
	VelocityFunc (enum easeIn / easeOut)
	funcStrength
	ThroughWalls   (bool)
	ThroughWatter  (bool)
	ThroughHoles   (bool)
	ThroughEnemies (bool)
	onColide (evento? enum?)

*TargetSpawnsEntity -        (lista?)
	Reference - FK para a entidade spawnada (objeto/critura actor? hitbox?)
	Relative Direction (facing)
	Is Position Binded To Parent (bool)
	Distance
	Random Offset (cria em algum lugar dentro da area)
	onCreateEffects // ActionEffect (Particles, hitboxes)
	
	*On position Occupied - 
		BEHAVIOUR (enum)
			Ignore
			cancelAction
			Push
			ForcePush
			
		maximum distance from origin
	
	*Hitbox Configuration -
		onColide (evento? enum? presets?) //Presets:
			Ignore
			Stop
			Push
			ForcePush
			SwitchPlaces
			Jump	
		onColideCallFunc // (enum) Chama essa funcao para cada objeto que colidir
```